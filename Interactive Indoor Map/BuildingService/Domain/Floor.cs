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
    public class Floor
    {
        [DataMember]
        public int FloorLevel { get; set; }

        public List<Room> Rooms { get; set; }

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

        [DataMember]
        public List<Sensor> Sensors { get; set; }

        public Floor(int floorLevel)
        {
            FloorLevel = floorLevel;
        }

        //[DataMember]
        //public List<WifiClient> Clients { get; set; }
    }
}