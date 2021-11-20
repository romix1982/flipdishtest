using Flipdish.Recruiting.Core.Services.EmailSender;
using Flipdish.Recruiting.WebhookReceiver;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]
namespace Flipdish.Recruiting.WebhookReceiver
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddHttpClient();
            builder.Services.AddTransient<IEmailService, EmailService>();
            builder.Services.AddTransient<ISmtpClientWrapper, SmtpClientWrapper>();
            builder.Services.AddTransient<IEmailRendererService, EmailRendererService>();
        }
    }
}
