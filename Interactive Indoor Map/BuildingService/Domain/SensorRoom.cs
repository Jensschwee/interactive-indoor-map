using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BuildingService.Domain
{
    [DataContract]
    public class SensorRoom : Room
    {
        [DataMember]
        public int Occupants { get; set; }

        [DataMember]
        public double VentilationConsumption { get; set; }

        [DataMember]
        public double LightConsumption { get; set; }

        [DataMember]
        public double HardwareConsumption { get; set; }

        [DataMember]
        public double OtherConsumption { get; set; }

        [DataMember]
        public double TotalConsumption => VentilationConsumption + LightConsumption + HardwareConsumption + OtherConsumption;
    }
}