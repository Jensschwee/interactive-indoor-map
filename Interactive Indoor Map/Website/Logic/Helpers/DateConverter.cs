using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Logic.Helpers
{
    public class DateConverter
    {
        public DateTime ConvertDate(int msSince1970)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(msSince1970);
        }
    }
}