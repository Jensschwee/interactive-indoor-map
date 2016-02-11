using System;
using Domain.Utility;

namespace Domain.Sensors
{
    abstract class Sensor
    {
        public string Name { get; set; }
        public Point Location { get; set; }

        protected Sensor(string name)
        {
            Name = name;
        }
    }
}
