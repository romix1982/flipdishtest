﻿using Flipdish.Recruiting.Core.Helpers;
using Flipdish.Recruiting.Core.Models;
using System;
using System.Globalization;

namespace Flipdish.Recruiting.UnitTest.Core.Services
{
    public interface IGeoService
    {
        string GetDynamicMapUrl(double centerLatitude, double centerLongitude, int zoom);
        string GetStaticMapUrl(double centerLatitude, double centerLongitude, int zoom, double? markerLatitude, double? markerLongitude, int width = 1200, int height = 1200);
        double GetAirDistance(Coordinates aCoords, Coordinates bCoords);
    }

    public class GeoService : IGeoService
    {
        public double GetAirDistance(Coordinates aCoords, Coordinates bCoords)
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
                var dist = Math.Sin(ConvertDegToRad(lat1)) * Math.Sin(ConvertDegToRad(lat2)) + Math.Cos(ConvertDegToRad(lat1)) * Math.Cos(ConvertDegToRad(lat2)) * Math.Cos(ConvertDegToRad(theta));
                dist = Math.Acos(dist);
                dist = ConvertRadToDeg(dist);
                dist = dist * 60 * 1.1515;

                dist *= 1.609344;

                return (dist);
            }
        }

        public string GetDynamicMapUrl(double centerLatitude, double centerLongitude, int zoom)
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

        public string GetStaticMapUrl(double centerLatitude, double centerLongitude, int zoom, double? markerLatitude, double? markerLongitude, int width = 1200, int height = 1200)
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

        private static string GetDms(double value)
        {
            var decimalDegrees = (double)value;
            var degrees = Math.Floor(decimalDegrees);
            var minutes = (decimalDegrees - Math.Floor(decimalDegrees)) * 60.0;
            var seconds = (minutes - Math.Floor(minutes)) * 60.0;
            var tenths = (seconds - Math.Floor(seconds)) * 1000.0;
            minutes = Math.Floor(minutes);
            seconds = Math.Floor(seconds);
            tenths = Math.Floor(tenths);

            var result = string.Format("{0}°{1}'{2}.{3}\"", degrees, minutes, seconds, tenths);

            return result;
        }

        private static double ConvertDegToRad(double deg) => (deg * Math.PI / 180.0);

        private static double ConvertRadToDeg(double rad) => (rad / Math.PI * 180.0);
    }
}
