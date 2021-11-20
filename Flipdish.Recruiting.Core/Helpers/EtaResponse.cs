using System;

namespace Flipdish.Recruiting.Core.Helpers
{
    //public enum EtaResponse
    //{
    //    None = 0,
    //    InMinutes = 1,
    //    TodayAt = 2,
    //    TomorrowAt = 3,
    //    OnDayAt = 4,
    //    AtDateTime = 5,
    //    OnDay = 6
    //}

    public static class EtaResponseMethods
    {
        public static string GetDateToFormattedString(DateTime requestedTime) => requestedTime.ToString($"dd MMM");

        public static string GetClocksToFormattedString(DateTime requestedTime) => requestedTime.ToString("HH:mm");
    }
}
