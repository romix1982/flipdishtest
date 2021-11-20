
namespace Flipdish.Recruiting.Core.Helpers
{
    static class CurrencyFilter
    {
        public static string currency(decimal input) => input.ToString("N2");
    }
}
