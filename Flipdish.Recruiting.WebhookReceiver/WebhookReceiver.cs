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
using Flipdish.Recruiting.WebhookReceiver.Models;
using System.Collections.Generic;
using Flipdish.Recruiting.Core.Services.EmailSender;

namespace Flipdish.Recruiting.WebhookReceiver
{
    public class WebhookReceiver
    {
        private readonly IEmailService _emailService;

        public WebhookReceiver(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [FunctionName("WebhookReceiver")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log,
            ExecutionContext context)
        {
            int? orderId = null;
            try
            {
                log.LogInformation("C# HTTP trigger function processed a request.");

                OrderCreatedWebhook orderCreatedWebhook;
                var queryInfo = new QueryEntity(req.Query);
                var test = queryInfo.DevEnvironment;

                if(req.Method == "GET" && !string.IsNullOrEmpty(test))
                {

                    var templateFilePath = Path.Combine(context.FunctionAppDirectory, "TestWebhooks", test);
                    var testWebhookJson = new StreamReader(templateFilePath).ReadToEnd();

                    orderCreatedWebhook = JsonConvert.DeserializeObject<OrderCreatedWebhook>(testWebhookJson);
                }
                else if (req.Method == "POST")
                {
                    var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                    orderCreatedWebhook = JsonConvert.DeserializeObject<OrderCreatedWebhook>(requestBody);
                }
                else
                {
                    throw new Exception("No body found or test param.");
                }
                var orderCreatedEvent = orderCreatedWebhook.Body;

                orderId = orderCreatedEvent.Order.OrderId;

                if (!queryInfo.StoreIds.Contains(orderCreatedEvent.Order.Store.Id.Value))
                {
                    log.LogInformation($"Skipping order #{orderId}");
                    return new ContentResult { Content = $"Skipping order #{orderId}", ContentType = "text/html" };
                }

                using EmailRenderer emailRenderer = new EmailRenderer(orderCreatedEvent.Order, orderCreatedEvent.AppId, queryInfo.MetadataKey, 
                    context.FunctionAppDirectory, log, queryInfo.Currency);
                
                var emailOrder = emailRenderer.RenderEmailOrder();

                try
                {
                    await _emailService.SendAsync("", queryInfo.EmailsTo, $"New Order #{orderId}", emailOrder, emailRenderer.ImagesWithNames);
                }
                catch(Exception ex)
                {
                    log.LogError($"Error occured during sending email for order #{orderId}" + ex);
                }

                log.LogInformation($"Email sent for order #{orderId}.", new { orderCreatedEvent.Order.OrderId });

                return new ContentResult { Content = emailOrder, ContentType = "text/html" };
            }
            catch(Exception ex)
            {
                log.LogError(ex, $"Error occured during processing order #{orderId}");
                throw ex;
            }
        }
    }
}
