using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Flipdish.Recruiting.UnitTest
{
    public class WebhookReceiverTest
    {
        private Mock<ILogger> _logger;
        //private Mock<IExecutionContext> _executionContext

        [SetUp]
        public void Setup() => _logger = new Mock<ILogger>();

        [Test]
        public void Test1()
        {
            //Arrange
            //IRestClient client = new RestClient($"{BaseUrl}/webhook/receiveWebHook.aspx");
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("Content-Type", "application/json");
            //request.AddHeader("messageType", "TestInsertNotification");
            //JObject jObjectbody = new JObject();
            //jObjectbody.Add("Alias", "Test");
            //jObjectbody.Add("TransactionID", "123");
            //request.AddParameter("application/json", jObjectbody, ParameterType.RequestBody);
            //var result = WebhookReceiver.WebhookReceiver.Run(request., _logger.Object, new ExecutionContext());
            //Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}