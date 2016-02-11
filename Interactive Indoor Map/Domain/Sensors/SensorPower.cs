using Domain.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Sensors
{
    class SensorPower : SensorResourceConsumption
    {
        public int VentilationConsumption { get; set; }
        public int LightConsumption { get; set; }
        public int HardwareConsumption { get; set; }
        public int OtherConsumption { get; set; }
        public override int TotalConsumption => VentilationConsumption + LightConsumption + HardwareConsumption + OtherConsumption;

        public SensorPower(string name) : base(name) { }
    }
}
