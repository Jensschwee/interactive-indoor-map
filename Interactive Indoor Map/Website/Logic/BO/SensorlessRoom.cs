using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.Logic.BO.Utility;

namespace Website.Logic.BO
{
    public class SensorlessRoom : Room
    {
        public List<Coordinates> Coordinates { get; set; }
    }
}