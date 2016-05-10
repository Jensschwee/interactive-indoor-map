using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Logic.Helpers
{
    public class DateConverter
    {
        public DateTime ConvertDate(long msSince1970)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(msSince1970).ToLocalTime();
        }

        public DateTime ConvertToLADate(DateTime time)
        {
            TimeZoneInfo timeZonePST = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
            TimeZoneInfo timeZoneCET = TimeZoneInfo.FindSystemTimeZoneById("Central Europe Standard Time");

            TimeSpan timeSpanPSTMinusUTC = timeZonePST.GetUtcOffset(time);
            TimeSpan timeSpanCETMinusUTC = timeZoneCET.GetUtcOffset(DateTime.Now);

            return time.AddHours(timeSpanPSTMinusUTC.Hours).AddHours(-timeSpanCETMinusUTC.Hours);
        }
    }
}