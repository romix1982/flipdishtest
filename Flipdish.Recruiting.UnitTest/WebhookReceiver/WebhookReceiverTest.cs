using Flipdish.Recruiting.Core.Services.EmailSender;
using Flipdish.Recruiting.UnitTest.Utils;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using Webhook = Flipdish.Recruiting.WebhookReceiver.WebhookReceiver;


namespace Flipdish.Recruiting.UnitTest.WebhookReceiver
{
    public class WebhookReceiverTest
    {
        private Mock<IEmailService> _emailService;
        private Mock<IEmailRendererService> _emailRendererService;
        private readonly ILogger logger = RequestHelper.CreateLogger();
        private ExecutionContext _executionContext;
        private Webhook _webhookReceiver;

        [SetUp]
        public void Setup()
        {
            _emailService = new Mock<IEmailService>();
            _emailRendererService = new Mock<IEmailRendererService>();
            _executionContext = new ExecutionContext
            {
                FunctionAppDirectory = "PATH"
            };

            _webhookReceiver = new Webhook(_emailService.Object, _emailRendererService.Object);
        }

        [Test]
        public void Run_should_throw_exception_no_body()
        {
            var log = (DummyLogger)RequestHelper.CreateLogger(LoggerTypes.List);
            var request = RequestHelper.CreateHttpRequest("post");

            //Act
            //Assert
            Assert.ThrowsAsync<ArgumentNullException>(() => _webhookReceiver.Run(request, log, _executionContext));
            Assert.IsNotEmpty(log.Logs);
            Assert.True(log.Logs.Contains("No body found or test param."));
        }

        [Test]
        public void Run_should_()
        {
            //Arrenge
            //_emailRendererService.Setup(x => x.RenderEmailOrder(It.IsAny<Order>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Currency>()));
            //_emailService.Setup(x => x.SendAsync(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Dictionary<string, Stream>>(), It.IsAny<IEnumerable<string>>()));

            var request = RequestHelper.CreateHttpRequest("post");

            //Act
            //Assert
            Assert.ThrowsAsync<ArgumentNullException>(() => _webhookReceiver.Run(request, logger, _executionContext));

        }
    }
}