
namespace Flipdish.Recruiting.Core.Helpers
{
    static class CurrencyFilter
    {
        public static string Currency(decimal input) => input.ToString("N2");
    }
}
