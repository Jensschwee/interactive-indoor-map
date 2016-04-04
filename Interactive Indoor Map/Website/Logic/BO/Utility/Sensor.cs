using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Website.Logic.BO.Utility
{
    public class Sensor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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