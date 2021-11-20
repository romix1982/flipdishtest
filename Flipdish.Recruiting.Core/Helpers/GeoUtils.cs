
using System;
using System.Globalization;
using Flipdish.Recruiting.Core.Models;

namespace Flipdish.Recruiting.Core.Helpers
{
    public static class GeoUtils
    {
        public static string GetDynamicMapUrl(double centerLatitude, double centerLongitude, int zoom)
        {
            string direction;
            double absoluteValue;
            if (centerLatitude < 0)
            {
                direction = "S";
                absoluteValue = -centerLatitude;
            }
            else
            {
                direction = "N";
                absoluteValue = centerLatitude;
            }

            var dmsLatitude = GetDms(absoluteValue) + direction;

            if (centerLongitude < 0)
            {
                direction = "W";
                absoluteValue = -centerLongitude;
            }
            else
            {
                direction = "E";
                absoluteValue = centerLongitude;
            }

            var dmsLongitude = GetDms(absoluteValue) + direction;

            var url = string.Format("https://www.google.ie/maps/place/{0}+{1}/@{2},{3},{4}z", dmsLatitude, dmsLongitude, centerLatitude, centerLongitude, zoom);
            return url;
        }
        private static string GetDms(double value)
        {
            var decimalDegrees = (double)value;
            var degrees = Math.Floor(decimalDegrees);
            var minutes = (decimalDegrees - Math.Floor(decimalDegrees)) * 60.0;
            var seconds = (minutes - Math.Floor(minutes)) * 60.0;
            var tenths = (seconds - Math.Floor(seconds)) * 1000.0;
            // get rid of fractional part
            minutes = Math.Floor(minutes);
            seconds = Math.Floor(seconds);
            tenths = Math.Floor(tenths);

            var result = string.Format("{0}°{1}'{2}.{3}\"", degrees, minutes, seconds, tenths);

            return result;
        }

        public static string GetStaticMapUrl(double centerLatitude, double centerLongitude, int zoom, double? markerLatitude,  double? markerLongitude, int width = 1200, int height = 1200)
        {

            var googleStaticMapsApiKey = SettingsService.Google_StaticMapsApiKey;

            var keyString = string.IsNullOrWhiteSpace(googleStaticMapsApiKey) ? "" : "&key=" + googleStaticMapsApiKey;
            var markerLatitudeStr = markerLatitude.HasValue ? markerLatitude.Value.ToString(CultureInfo.InvariantCulture) : "0";
            var markerLongitudeStr = markerLongitude.HasValue ? markerLongitude.Value.ToString(CultureInfo.InvariantCulture) : "0";

            const string mapBaseUri = "https://maps.googleapis.com/maps/api/staticmap?center={0},{1}&scale=2&zoom={2}&size={6}x{7}&format=png32&scale=1&maptype=roadmap&markers=size:mid|{3},{4}{5}";

            var mapFullUri = string.Format(mapBaseUri, centerLatitude.ToString(CultureInfo.InvariantCulture), centerLongitude.ToString(CultureInfo.InvariantCulture),
                zoom.ToString(CultureInfo.InvariantCulture), markerLatitudeStr,
                markerLongitudeStr, keyString, width.ToString(CultureInfo.InvariantCulture),
                height.ToString(CultureInfo.InvariantCulture));

            return mapFullUri;
        }

        public static double GetAirDistance(Coordinates aCoords, Coordinates bCoords)
        {
            var lat1 = aCoords.Latitude.Value;
            var lat2 = bCoords.Latitude.Value;
            var lon1 = aCoords.Longitude.Value;
            var lon2 = bCoords.Longitude.Value;
            if ((lat1 == lat2) && (lon1 == lon2))
            {
                return 0;
            }
            else
            {
                var theta = lon1 - lon2;
                var dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
                dist = Math.Acos(dist);
                dist = rad2deg(dist);
                dist = dist * 60 * 1.1515;

                dist = dist * 1.609344;

                return (dist);
            }
        }

        private static double deg2rad(double deg) => (deg * Math.PI / 180.0);

        private static double rad2deg(double rad) => (rad / Math.PI * 180.0);
    }
}
