using System;
using System.Globalization;

namespace SendGridDemo.Data.Utilities
{
    public static class DateTimeMixins
    {
        public static string UtcTimeToPacificStandardTimeAsStringShort(this DateTime time)
        {
            var pacificStandardTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
            var pacificStandardTime = TimeZoneInfo.ConvertTimeFromUtc(time, pacificStandardTimeZone);
            var abbreviation = pacificStandardTimeZone.IsDaylightSavingTime(time)
                ? "PDT"
                : "PST";
            var ret = pacificStandardTime.ToString("MM-dd hh:mm tt", CultureInfo.CurrentCulture)
                      + " " + abbreviation;
            return ret;
        }
    }
}
