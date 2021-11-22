using Flipdish.Recruiting.Core.Models;
using Flipdish.Recruiting.Core.Services.EmailSender;
using Flipdish.Recruiting.UnitTest.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Webhook = Flipdish.Recruiting.WebhookReceiver.WebhookReceiver;


namespace Flipdish.Recruiting.UnitTest.WebhookReceiver
{
    public class WebhookReceiverTest
    {
        private Mock<IEmailService> _emailService;
        private Mock<IEmailRendererService> _emailRendererService;
        private Mock<IOptions<SmtpConfig>> _stmpConfig;
        private const string BodyResourceName = "Flipdish.Recruiting.UnitTest.Resources.BodySample.json";
        private ExecutionContext _executionContext;
        private Webhook _webhookReceiver;

        [SetUp]
        public void Setup()
        {
            _emailService = new Mock<IEmailService>();
            _emailRendererService = new Mock<IEmailRendererService>();
            _stmpConfig = new Mock<IOptions<SmtpConfig>>();
            _executionContext = new ExecutionContext
            {
                FunctionAppDirectory = "PATH"
            };
            _stmpConfig.Setup(x => x.Value).Returns(new SmtpConfig());
            _webhookReceiver = new Webhook(_emailService.Object, _emailRendererService.Object, _stmpConfig.Object);
        }

        [Test]
        public void Run_should_throw_unknown_request_method_exception()
        {
            //Arrange
            var log = (DummyLogger)RequestHelper.CreateLogger(LoggerTypes.List);
            var request = RequestHelper.CreateHttpRequest("UNKNOWN");

            //Act
            //Assert
            Assert.ThrowsAsync<ArgumentNullException>(() => _webhookReceiver.Run(request, log, _executionContext));
            Assert.IsNotEmpty(log.Logs);
            Assert.True(log.Logs.Contains("Unknown request methdod."));
        }

        [Test]
        public void Run_should_throw_no_test_param_exception()
        {
            //Arrange
            var log = (DummyLogger)RequestHelper.CreateLogger(LoggerTypes.List);
            var request = RequestHelper.CreateHttpRequest("GET");

            //Act
            //Assert
            Assert.ThrowsAsync<ArgumentNullException>(() => _webhookReceiver.Run(request, log, _executionContext));
            Assert.IsNotEmpty(log.Logs);
            Assert.True(log.Logs.Contains("No test param found."));
        }

        [Test]
        public void Run_should_throw_no_body_exception()
        {
            //Arrange
            var log = (DummyLogger)RequestHelper.CreateLogger(LoggerTypes.List);
            var request = RequestHelper.CreateHttpRequest("POST");

            //Act
            //Assert
            Assert.ThrowsAsync<ArgumentNullException>(() => _webhookReceiver.Run(request, log, _executionContext));
            Assert.IsNotEmpty(log.Logs);
            Assert.True(log.Logs.Contains("No body found."));
        }

        [Test]
        public async Task Run_should_return_contentResult_not_null()
        {
            //Arrange
            var emailRenderer = "Email Renderder";
            var log = (DummyLogger)RequestHelper.CreateLogger(LoggerTypes.List);
            var bodyBytes = ResourceLoader.GetResourceBytes(BodyResourceName);
            var streamBody = new MemoryStream(bodyBytes);
            _emailRendererService.Setup(x => x.RenderEmailOrder(It.IsAny<Order>(), It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<Currency>())).Returns(emailRenderer);
            _emailService.Setup(x => x.SendAsync(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<string>(), 
                It.IsAny<string>(), It.IsAny<Dictionary<string, Stream>>(), It.IsAny<IEnumerable<string>>()));
            var request = RequestHelper.CreateHttpRequest("POST", streamBody);

            //Act
            var result = await _webhookReceiver.Run(request, log, _executionContext);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(emailRenderer, ((ContentResult)result).Content);
            Assert.IsNotEmpty(log.Logs);
            Assert.True(log.Logs.Any(l => l.StartsWith("Email sent")));
        }
    }
}