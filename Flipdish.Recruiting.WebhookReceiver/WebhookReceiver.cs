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
    public interface IWebhookReceiver
    {
        Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req, ILogger log, ExecutionContext context);
    }

    public class WebhookReceiver : IWebhookReceiver
    {
        private readonly IEmailService _emailService;
        private readonly IEmailRendererService _emailRendererService;
        private ILogger _logger;

        public WebhookReceiver(IEmailService emailService, IEmailRendererService emailRendererService)
        {
            _emailService = emailService;
            _emailRendererService = emailRendererService;
        }

        [FunctionName("WebhookReceiver")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req, ILogger log, ExecutionContext context)
        {
            _logger = log;
            try
            {
                log.LogInformation("C# HTTP trigger function processed a request.");
                var queryInfo = new QueryInfo(req.Query);

                var orderCreatedWebhook = req.Method switch
                {
                    "GET" => GetAction(context, queryInfo),
                    "POST" => await PostActionAsync(req),
                    _ => UnknownMethodError()
                };

                return await ProcessOrder(orderCreatedWebhook.Body, queryInfo, context);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Private Methods
        private async Task<ContentResult> ProcessOrder(OrderCreatedEvent orderCreatedEvent, QueryInfo queryInfo, ExecutionContext context)
        {
            var orderId = orderCreatedEvent.Order.OrderId;
            try
            {
                if (!MatchStoreIdAndOrderStoreId(queryInfo, orderCreatedEvent))
                {
                    _logger.LogInformation($"Skipping order #{orderId}");
                    return new ContentResult { Content = $"Skipping order #{orderId}", ContentType = "text/html" };
                }

                var emailOrder = CreateEmailOrder(context, orderId, queryInfo, orderCreatedEvent);
                await SendEmailOrder(orderId, queryInfo, emailOrder);

                _logger.LogInformation($"Email sent for order #{orderId}.", new { orderCreatedEvent.Order.OrderId });

                return new ContentResult { Content = emailOrder, ContentType = "text/html",};
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occured during processing order #{orderId}");
                throw;
            }
        }

        private async Task SendEmailOrder(int? orderId, QueryInfo queryInfo, string emailOrder)
        {
            try
            {
                await _emailService.SendAsync("", queryInfo.EmailsTo, $"New Order #{orderId}", emailOrder, _emailRendererService.ImagesWithNames);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured during sending email for order #{orderId}" + ex);
                throw;
            }
        }

        private string CreateEmailOrder(ExecutionContext context, int? orderId, QueryInfo queryInfo, OrderCreatedEvent orderCreatedEvent)
        {
            try
            {
               return _emailRendererService.RenderEmailOrder(orderCreatedEvent.Order, orderCreatedEvent.AppId, queryInfo.MetadataKey,
                context.FunctionAppDirectory, queryInfo.Currency);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured during email redering for order #{orderId}" + ex);
                throw;
            }
        }

        private OrderCreatedWebhook GetAction(ExecutionContext context, QueryInfo queryInfo)
        {
            if (IsDevEnvironment(queryInfo.DevEnvironment))
            {
                var templateFilePath = Path.Combine(context.FunctionAppDirectory, "TestWebhooks", queryInfo.DevEnvironment);
                var testWebhookJson = new StreamReader(templateFilePath).ReadToEnd();

                return JsonConvert.DeserializeObject<OrderCreatedWebhook>(testWebhookJson);
            }
            else
            {
                var errorMessage = "No test param found.";
               _logger.LogError(errorMessage);
                throw new ArgumentNullException(errorMessage);
            }
        }

        private async Task<OrderCreatedWebhook> PostActionAsync(HttpRequest req)
        {
            try
            {
                var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                return JsonConvert.DeserializeObject<OrderCreatedWebhook>(requestBody);
            }
            catch (Exception ex )
            {
                var errorMessage = "No body found.";
               _logger.LogError(errorMessage);
                throw new ArgumentNullException(errorMessage, ex);
            }
        }

        private OrderCreatedWebhook UnknownMethodError()
        {
            var errorMessage = "Unknown request methdod.";
            _logger.LogInformation(errorMessage);
            throw new ArgumentNullException(errorMessage);
        }

        private bool IsDevEnvironment(string testParam) => !string.IsNullOrEmpty(testParam);

        private bool MatchStoreIdAndOrderStoreId(QueryInfo query, OrderCreatedEvent orderCreatedEvent) => query.StoreIds.Contains(orderCreatedEvent.Order.Store.Id.Value);
        #endregion
    }
}
