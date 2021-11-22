using Flipdish.Recruiting.Core.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Flipdish.Recruiting.WebhookReceiver
{
    public class QueryInfo
    {
        private readonly string _devEnvironment;
        private readonly string _metadaKey;
        private readonly IEnumerable<int> _storeIds;
        private readonly Currency _currency;
        private readonly IEnumerable<string> _emailsTo;

        public string DevEnvironment => _devEnvironment;
        public IEnumerable<int> StoreIds => _storeIds;
        public Currency Currency => _currency;
        public string MetadataKey => _metadaKey;
        public IEnumerable<string> EmailsTo => _emailsTo;


        public QueryInfo(IQueryCollection query)
        {
            _devEnvironment = query["test"];
            _storeIds = GetStoreIdList(query["storeId"].ToArray());
            _currency = SetCurrency(query["currency"]);
            _metadaKey = SetMetadataKey(query["metadataKey"]);
            _emailsTo = GetEmailsTo(query["to"].ToArray());
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

        private IEnumerable<string> GetEmailsTo(IEnumerable<string> queryTo) => queryTo.Any() ? queryTo : throw new ArgumentNullException("Parameter TO is missing in the request URL");

        private string SetMetadataKey(string metadataKey) => !string.IsNullOrEmpty(metadataKey) ? metadataKey : "eancode";
    }
}
