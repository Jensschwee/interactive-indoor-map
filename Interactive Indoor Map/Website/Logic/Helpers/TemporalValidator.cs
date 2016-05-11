using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Logic.Helpers
{
    public class TemporalValidator
    {

        public static DateTime ValidateDate(DateTime date)
        {
            if (date > DateTime.Now)
            {
                date = DateTime.Now;
            }
            return date;
        }
    }
}