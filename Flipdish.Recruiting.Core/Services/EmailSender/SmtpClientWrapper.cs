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

        public SmtpClient SmtpClient { get; set; }
        public SmtpClientWrapper()
        {
        }
        public async Task Send(MailMessage mailMessage) => await Task.Delay(2);
    }
}

//var smtpClient = new SmtpClient("smtp.gmail.com")
//{
//    Port = 587,
//    Credentials = new NetworkCredential("email", "password"),
//    EnableSsl = true,
//};