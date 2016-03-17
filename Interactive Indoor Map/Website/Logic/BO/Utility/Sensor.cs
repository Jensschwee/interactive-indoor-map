using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Website.Logic.BO.Utility
{
    public class Sensor
    {
        public string SensorName { get; set; }
        public string SensorType { get; set; }
        public Coordinates Coordinates { get; set; }

        public Sensor(string sensorName, string sensorType)
        {
            SensorName = sensorName;
            SensorType = sensorType;
        }
    }
}