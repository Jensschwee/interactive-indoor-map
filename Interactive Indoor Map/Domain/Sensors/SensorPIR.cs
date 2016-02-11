using Domain.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Sensors
{
    class SensorPIR : Sensor
    {
        public bool IsMovementDetected { get; set; }

        public SensorPIR(string name) : base(name) { }
    }
}
