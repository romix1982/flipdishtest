﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Flipdish.Recruiting.Core.Helpers
{
    public static class CurrencyCodeMapper
    {
        private static readonly Dictionary<string, string> _symbolsByCode;

        public static string IsoCodeToSymbol(string isoCode) => _symbolsByCode[isoCode];

        static CurrencyCodeMapper()
        {
            try
            {
                _symbolsByCode = new Dictionary<string, string>();
                IEnumerable<RegionInfo> regions = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                    .Select(x => new RegionInfo(x.Name))
                    .ToList();

                foreach (var region in regions)
                {
                    if (!_symbolsByCode.ContainsKey(region.ISOCurrencySymbol.ToUpper()))
                    {
                        _symbolsByCode.Add(region.ISOCurrencySymbol.ToUpper(), region.CurrencySymbol);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}