using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Flipdish.Recruiting.Core.Services.EmailSender
{
    public interface IEmailService
    {
        public Task SendAsync(string from, IEnumerable<string> to, string subject, string body, Dictionary<string, Stream> attachements, IEnumerable<string> cc = null);

    }

    public class EmailService : IEmailService
    {
        private readonly ISmtpClientWrapper _smtpClientWrapper;

        public EmailService(ISmtpClientWrapper smtpClientWrapper)
        {
            _smtpClientWrapper = smtpClientWrapper;
        }

        public async Task SendAsync(string from, IEnumerable<string> to, string subject, string body, Dictionary<string, Stream> attachements, IEnumerable<string> cc = null)
        {
            var mailMessage = new MailMessage
            {
                IsBodyHtml = true,
                From = new MailAddress(from),
                Subject = subject,
                Body = body
            };

            AddToEmails(to, mailMessage);
            AddCCEmails(cc, mailMessage);
            AddAttachements(attachements, mailMessage);
            await SendEmailAsync(mailMessage);
        }

        #region Private Methods
        private async Task SendEmailAsync(MailMessage mailMessage) => await _smtpClientWrapper.Send(mailMessage);

        private static void AddAttachements(Dictionary<string, Stream> attachements, MailMessage mailMessage)
        {
            foreach (var nameAndStreamPair in attachements)
            {
                var attachment = new Attachment(nameAndStreamPair.Value, nameAndStreamPair.Key)
                {
                    ContentId = nameAndStreamPair.Key
                };

                mailMessage.Attachments.Add(attachment);
            }
        }

        private static void AddCCEmails(IEnumerable<string> cc, MailMessage mailMessage)
        {
            if (cc != null)
            {
                foreach (var ccEmail in cc)
                {
                    mailMessage.To.Add(ccEmail);
                }
            }
        }

        private static void AddToEmails(IEnumerable<string> to, MailMessage mailMessage)
        {
            foreach (var email in to)
            {
                mailMessage.To.Add(email);
            }
        }
        #endregion
    }
}
