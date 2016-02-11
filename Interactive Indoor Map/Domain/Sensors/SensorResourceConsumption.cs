using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Sensors
{
    abstract class SensorResourceConsumption : Sensor
    {
        public virtual int TotalConsumption
        {
            get { throw new NotImplementedException(); }
        }

        protected SensorResourceConsumption(string name) : base(name) { }
    }
}