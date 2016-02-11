using Domain.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Sensors
{
    class SensorWater : SensorResourceConsumption
    {
        public int HotWaterConsumption { get; set; }
        public int ColdWaterConsumption { get; set; }
        public override int TotalConsumption => HotWaterConsumption + ColdWaterConsumption;

        public SensorWater(string name) : base(name) { }
    }
}
