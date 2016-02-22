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
    public class Room
    {
        [DataMember]
        public string RoomName { get; set; }

        [DataMember]
        public Area Area { get; set; }

        [DataMember]
        public bool IsLightActivated { get; set; }

        [DataMember]
        public int Lumen { get; set; }

        [DataMember]
        public bool IsMotionDetected { get; set; }

        [DataMember]
        public double Temperature { get; set; }

        [DataMember]
        public int CO2 { get; set; }

        //[DataMember]
        //public List<WifiClient> Clients { get; set; }

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