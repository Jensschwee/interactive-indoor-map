using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Logic.BO.Utility
{
    public class SMapSensorReading
    {
        public string uuid { get; set; }
        public List<List<double>> Readings { get; set; }
    }
}