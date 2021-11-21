using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System.IO;

namespace Flipdish.Recruiting.UnitTest.Utils
{
    public class RequestHelper
    {
        public static IEnumerable<object[]> Data()
        {
            return new List<object[]>
            {
                new object[] { "to", "john.doe@mail.com" },
                new object[] { "currency", "eur" },
                new object[] { "metadatakey", "eancode" },
                new object[] { "storeId", "1234" }
            };
        }

        private static Dictionary<string, StringValues> CreateDictionary()
        {
            var query = new Dictionary<string, StringValues>
            {
                { "to", new StringValues( new string[] { "john.doe@mail.com", "jane.doe@mail.com" })},
                { "currency", "eur" },
                { "metadatakey", "eancode" },
                { "storeId", new StringValues( new string[] {"1234", "12345" })}
            };
            return query;
        }

        public static HttpRequest CreateHttpRequest(string method, Stream body = null)
        {
            var context = new DefaultHttpContext();
            var request = context.Request;
            request.Method = method;
            request.Body = body;
            request.Query = new QueryCollection(CreateDictionary());
            return request;
        }

        public static ILogger CreateLogger(LoggerTypes type = LoggerTypes.Null)
        {
            ILogger logger;

            if (type == LoggerTypes.List)
            {
                logger = new DummyLogger();
            }
            else
            {
                logger = NullLoggerFactory.Instance.CreateLogger("Null Logger");
            }

            return logger;
        }
    }
}
