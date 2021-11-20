using Flipdish.Recruiting.Core.Services.EmailSender;
using NUnit.Framework;

namespace Flipdish.Recruiting.UnitTest.Core.Services.EmailSender
{
    [TestFixture]
    public class EmailServiceTest
    {
        private readonly EmailService _emailService;

        [SetUp]
        public void SetUp()
        {
           // _emailService = new EmailService();
        }

        [Test]
        public void SendAsync_should_sent_email()
        {

        }
    }
}
