using Domain.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Sensors
{
    class SensorWifi : Sensor
    {
        public List<WifiClient> Clients { get; set; }

        public SensorWifi(string name) : base(name) { }
    }
}
