using Flipdish.Recruiting.Core.Helpers;
using Flipdish.Recruiting.Core.Services.EmailSender;
using Flipdish.Recruiting.UnitTest.Core.Services;
using Flipdish.Recruiting.WebhookReceiver;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.IO;

[assembly: FunctionsStartup(typeof(Startup))]
namespace Flipdish.Recruiting.WebhookReceiver
{
    public class Startup : FunctionsStartup
    {
        private IConfigurationRoot _functionConfig = null;

        private IConfigurationRoot FunctionConfig(string appDir) =>
            _functionConfig ??= new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(appDir, "appsettings.json"), optional: true, reloadOnChange: true)
                .Build();

        public override void Configure(IFunctionsHostBuilder builder)
        {
            //IConfiguration configuration = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //    .AddEnvironmentVariables()
            //    .Build();

            builder.Services.AddOptions<SettingsService>()
             .Configure<IOptions<ExecutionContextOptions>>((mlSettings, exeContext) =>
                 FunctionConfig(exeContext.Value.AppDirectory).GetSection("Settings").Bind(mlSettings));

            builder.Services.AddOptions<SmtpConfig>()
            .Configure<IOptions<ExecutionContextOptions>>((mlSettings, exeContext) =>
                FunctionConfig(exeContext.Value.AppDirectory).GetSection("SmtpClientConfig").Bind(mlSettings));


            builder.Services.AddHttpClient();
            builder.Services.AddTransient<IEmailService, EmailService>();
            builder.Services.AddTransient<ISmtpClientWrapper, SmtpClientWrapper>();
            builder.Services.AddTransient<IEmailRendererService, EmailRendererService>();
            builder.Services.AddTransient<IGeoService, GeoService>();
        }
    }
}
