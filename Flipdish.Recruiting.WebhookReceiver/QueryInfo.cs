using Flipdish.Recruiting.Core.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Flipdish.Recruiting.WebhookReceiver
{
    public class QueryInfo
    {
        public string DevEnvironment { get; set; }
        public  IEnumerable<int> StoreIds { get; set; }
        public Currency  Currency { get; set; }
        public string MetadataKey { get; set; }
        public IEnumerable<string> EmailsTo { get; set; }

        public QueryInfo(IQueryCollection query)
        {
            DevEnvironment = query["test"];
            StoreIds = GetStoreIdList(query["storeId"].ToArray());
            Currency = SetCurrency(query["currency"]);
            MetadataKey = query["metadataKey"].First() ?? "eancode";
            EmailsTo = query["to"].ToArray();
        }

        private Currency SetCurrency(string currencyString)
        {
            if (!string.IsNullOrEmpty(currencyString) && Enum.TryParse(typeof(Currency), currencyString.ToUpper(), out var currencyObject))
            {
                return (Currency)currencyObject;
            }
            return Currency.EUR;
        }

        private IEnumerable<int> GetStoreIdList(IEnumerable<string> queryStoredIds)
        {
            var storeIds = new List<int>();
            foreach (var storeIdString in queryStoredIds)
            {
                var storeId = 0;
                try
                {
                    storeId = int.Parse(storeIdString);
                }
                catch (Exception) { }

                storeIds.Add(storeId);
            }
            return storeIds;
        }
    }
}
