using System;

namespace TweetGetter.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToUTC(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");
        }

        public static string ToUTCView(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-ddTHH:mm");
        }
    }
}
