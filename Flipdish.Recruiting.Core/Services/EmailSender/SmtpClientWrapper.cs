using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Flipdish.Recruiting.Core.Services.EmailSender
{
    public interface ISmtpClientWrapper
    {
        Task Send(MailMessage mailMessage);
    }

    public class SmtpClientWrapper : ISmtpClientWrapper
    {
        private SmtpConfig _stmpConfig;
        public SmtpClient SmtpClient { get; set; }

        public SmtpClientWrapper(IOptions<SmtpConfig> stmpConfig)
        {
            _stmpConfig = stmpConfig.Value;

            SmtpClient = new SmtpClient(_stmpConfig.Host)
            {
                Port = Convert.ToInt32(_stmpConfig.Port),
                Credentials = new NetworkCredential(_stmpConfig.UserName, _stmpConfig.Password),
                EnableSsl = true,
            };
        }

        public async Task Send(MailMessage mailMessage)
        {
            try
            {
                await SmtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception)
            {}
        }
    }
}

