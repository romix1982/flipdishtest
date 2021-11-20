using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Flipdish.Recruiting.Core.Models;
using Flipdish.Recruiting.Core.Services.EmailSender;

namespace Flipdish.Recruiting.WebhookReceiver
{
    public class WebhookReceiver
    {
        private readonly IEmailService _emailService;
        private readonly IEmailRendererService _emailRendererService;

        public WebhookReceiver(IEmailService emailService, IEmailRendererService emailRendererService)
        {
            _emailService = emailService;
            _emailRendererService = emailRendererService;
        }

        [FunctionName("WebhookReceiver")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req, ILogger log, ExecutionContext context)
        {
            try
            {
                log.LogInformation("C# HTTP trigger function processed a request.");
                var queryInfo = new QueryInfo(req.Query);

                var orderCreatedWebhook = new OrderCreatedWebhook();
                orderCreatedWebhook = req.Method switch
                {
                    "GET" => GetAction(context, queryInfo, orderCreatedWebhook),
                    "POST" => await PostActionAsync(req),
                    _ => throw new Exception("No body found or test param."),
                };

                return await ProcessOrder(orderCreatedWebhook.Body, queryInfo, context, log);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Private Methods
        private async Task<ContentResult> ProcessOrder(OrderCreatedEvent orderCreatedEvent, QueryInfo queryInfo, ExecutionContext context, ILogger log)
        {
            var orderId = orderCreatedEvent.Order.OrderId;
            try
            {
                if (!MatchStoreIdAndOrderStoreId(queryInfo, orderCreatedEvent))
                {
                    log.LogInformation($"Skipping order #{orderId}");
                    return new ContentResult { Content = $"Skipping order #{orderId}", ContentType = "text/html" };
                }

                var emailOrder = CreateEmailOrder(log, context, orderId, queryInfo, orderCreatedEvent);
                await SendEmailOrder(log, orderId, queryInfo, emailOrder);

                log.LogInformation($"Email sent for order #{orderId}.", new { orderCreatedEvent.Order.OrderId });

                return new ContentResult { Content = emailOrder, ContentType = "text/html" };
            }
            catch (Exception ex)
            {
                log.LogError(ex, $"Error occured during processing order #{orderId}");
                throw;
            }
        }

        private async Task SendEmailOrder(ILogger log, int? orderId, QueryInfo queryInfo, string emailOrder)
        {
            try
            {
                await _emailService.SendAsync("", queryInfo.EmailsTo, $"New Order #{orderId}", emailOrder, _emailRendererService.ImagesWithNames);
            }
            catch (Exception ex)
            {
                log.LogError($"Error occured during sending email for order #{orderId}" + ex);
                throw;
            }
        }

        private string CreateEmailOrder(ILogger log, ExecutionContext context, int? orderId, QueryInfo queryInfo, OrderCreatedEvent orderCreatedEvent)
        {
            try
            {
               return _emailRendererService.RenderEmailOrder(orderCreatedEvent.Order, orderCreatedEvent.AppId, queryInfo.MetadataKey,
                context.FunctionAppDirectory, queryInfo.Currency);
            }
            catch (Exception ex)
            {
                log.LogError($"Error occured during email redering for order #{orderId}" + ex);
                throw;
            }
        }

        private OrderCreatedWebhook GetAction(ExecutionContext context, QueryInfo queryInfo, OrderCreatedWebhook orderCreatedWebhook)
        {
            if (IsDevEnvironment(queryInfo.DevEnvironment))
            {
                var templateFilePath = Path.Combine(context.FunctionAppDirectory, "TestWebhooks", queryInfo.DevEnvironment);
                var testWebhookJson = new StreamReader(templateFilePath).ReadToEnd();

                orderCreatedWebhook = JsonConvert.DeserializeObject<OrderCreatedWebhook>(testWebhookJson);
            }

            return orderCreatedWebhook;
        }

        private async Task<OrderCreatedWebhook> PostActionAsync(HttpRequest req)
        {
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            return JsonConvert.DeserializeObject<OrderCreatedWebhook>(requestBody);
        }

        private bool IsDevEnvironment(string testParam) => !string.IsNullOrEmpty(testParam);

        private bool MatchStoreIdAndOrderStoreId(QueryInfo query, OrderCreatedEvent orderCreatedEvent) => query.StoreIds.Contains(orderCreatedEvent.Order.Store.Id.Value);
        #endregion
    }
}
