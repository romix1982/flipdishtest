using Flipdish.Recruiting.Core.Services.EmailSender;
using Moq;
using NUnit.Framework;

namespace Flipdish.Recruiting.UnitTest.Core.Services.EmailSender
{
    [TestFixture]
    public class EmailServiceTest
    {
        private Mock<ISmtpClientWrapper> _smtpClientWrapper;
        private EmailService _emailService;

        [SetUp]
        public void SetUp()
        {
            _smtpClientWrapper = new Mock<ISmtpClientWrapper>();
           _emailService = new EmailService(_smtpClientWrapper.Object);
        }

        [Test]
        public void SendAsync_should_sent_email()
        {

        }
    }
}
