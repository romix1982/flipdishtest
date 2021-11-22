using Flipdish.Recruiting.Core.Models;
using System.Globalization;
using System.Net;
using System.Threading;

namespace Flipdish.Recruiting.Core.Helpers.CurrencyUtils
{
    public static class CurrencyExtensions
    {
        public static string ToRawHtmlCurrencyString(this decimal l, Currency currency)
        {
            var currencyString = l.ToCurrencyString(currency);
            var result = WebUtility.HtmlEncode(currencyString);
            result = result.Replace(" ", "&nbsp;");

            return result;
        }

        public static string ToRawHtmlCurrencyString(this double l, Currency currency)
        {
            var currencyString = l.ToCurrencyString(currency);
            var result = WebUtility.HtmlEncode(currencyString);
            result = result.Replace(" ", "&nbsp;");

            return result;
        }

        private static string ToCurrencyString(this decimal l, Currency currency, CultureInfo cultureInfo)
        {
            var numberFormatInfo = cultureInfo.NumberFormat;
            numberFormatInfo.CurrencySymbol = currency.ToSymbol();

            var formattedPrice = l.ToString("C", numberFormatInfo);

            return formattedPrice;
        }

        private static string ToSymbol(this Currency c) => c.GetCurrencyItem().Symbol;

        private static CurrencyItem GetCurrencyItem(this Currency currency)
        {
            CurrencyItem ci = new CurrencyItem
            {
                Currency = currency,
                IsoCode = currency.ToString().ToUpper(),
                Symbol = CurrencyCodeMapper.IsoCodeToSymbol(currency.ToString().ToUpper())
            };

            return ci;
        }

        private static string ToCurrencyString(this double l, Currency currency, CultureInfo cultureInfo)
        {
            var numberFormatInfo = cultureInfo.NumberFormat;
            numberFormatInfo.CurrencySymbol = currency.ToSymbol();

            var formattedPrice = l.ToString("C", numberFormatInfo);

            return formattedPrice;
        }

        private static string ToCurrencyString(this decimal l, Currency currency)
        {
            var cultureInfo = new CultureInfo(Thread.CurrentThread.CurrentUICulture.IetfLanguageTag);
            return ToCurrencyString(l, currency, cultureInfo);
        }

        private static string ToCurrencyString(this double l, Currency currency)
        {
            var cultureInfo = new CultureInfo(Thread.CurrentThread.CurrentUICulture.IetfLanguageTag);
            return ToCurrencyString(l, currency, cultureInfo);
        }
    }
}
