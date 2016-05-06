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

        public DateTime ConvertToLaDate(DateTime time)
        {
            TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
            TimeZoneInfo timeZoneCTE = TimeZoneInfo.FindSystemTimeZoneById("Central Europe Standard Time");


            TimeSpan newDateTime = timeZoneInfo.GetUtcOffset(time);

            TimeSpan timeSpan = timeZoneCTE.GetUtcOffset(DateTime.Now);

            return time.AddHours(newDateTime.Hours).AddHours(-timeSpan.Hours);
        }
    }
}