using Flipdish.Recruiting.Core.Services.EmailSender;
using Flipdish.Recruiting.WebhookReceiver;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
