using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Flipdish.Recruiting.UnitTest.Utils
{
    public class DummyLogger : ILogger
    {
        public IList<string> Logs;

        public IDisposable BeginScope<TState>(TState state) => NullScope.Instance;

        public bool IsEnabled(LogLevel logLevel) => false;

        public DummyLogger()
        {
            Logs = new List<string>();
        }

        public void Log<TState>(LogLevel logLevel,
                                EventId eventId,
                                TState state,
                                Exception exception,
                                Func<TState, Exception, string> formatter)
        {
            var message = formatter(state, exception);
            Logs.Add(message);
        }
    }
}
