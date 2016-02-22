using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.AccessControl;
using System.Web;
using BuildingService.Domain.Utility;

namespace BuildingService.Domain
{
    [DataContract]
    public class Building
    {
        public List<Floor> Floors { get; set; }

        [DataMember]
        public string BuildingName { get; set; }

        [DataMember]
        public int Occupants { get; set; }

        [DataMember]
        public double VentilationConsumption => Floors.Sum(floor => floor.VentilationConsumption);

        [DataMember]
        public double LightConsumption => Floors.Sum(floor => floor.LightConsumption);

        [DataMember]
        public double HardwareConsumption => Floors.Sum(floor => HardwareConsumption);

        [DataMember]
        public double OtherConsumption => Floors.Sum(floor => OtherConsumption);

        [DataMember]
        public double TotalPowerConsumption => VentilationConsumption + LightConsumption + HardwareConsumption + OtherConsumption;

        [DataMember]
        public double HotWaterConsumption { get; set; }

        [DataMember]
        public double ColdWaterConsumption { get; set; }

        //[DataMember]
        //public List<WifiClient> Clients { get; set; }

        //[DataMember]
        //public int WifiClients { get; set; }
    }
}