using System;

namespace Flipdish.Recruiting.Core.Helpers
{
    public static class EtaResponseMethods
    {
        public static string GetDateToFormattedString(DateTime requestedTime) => requestedTime.ToString($"dd MMM");

        public static string GetClocksToFormattedString(DateTime requestedTime) => requestedTime.ToString("HH:mm");
    }
}
