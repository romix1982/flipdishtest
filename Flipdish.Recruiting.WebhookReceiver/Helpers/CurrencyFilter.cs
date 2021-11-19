
namespace Flipdish.Recruiting.WebhookReceiver.Helpers
{
    static class CurrencyFilter
    {
        public static string currency(decimal input) => input.ToString("N2");
    }
}
