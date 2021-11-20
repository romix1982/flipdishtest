using Flipdish.Recruiting.Core.Services.EmailSender;
using NUnit.Framework;

namespace Flipdish.Recruiting.UnitTest
{
    [TestFixture]
    public class EmailServiceTest
    {
        private EmailService _emailService;

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
