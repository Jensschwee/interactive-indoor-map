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

        [DataMember]
        public List<Room> Rooms { get; set; }

        [DataMember]
        public double? VentilationConsumption { get; set; }

        [DataMember]
        public double? LightConsumption { get; set; }

        [DataMember]
        public double? HardwareConsumption { get; set; }

        [DataMember]
        public double? OtherConsumption { get; set; }

        [DataMember]
        public double? TotalConsumption
        {
            get { return VentilationConsumption + LightConsumption + HardwareConsumption + OtherConsumption; }
            set { TotalConsumption = value; }
        }
            

        [DataMember]
        public List<Sensor> Sensors { get; set; }

        public Floor(int floorLevel)
        {
            FloorLevel = floorLevel;
        }

        public Floor(Floor floorToCopy)
        {
            FloorLevel = floorToCopy.FloorLevel;

            foreach (var room in floorToCopy.Rooms)
            {
                Rooms.Add(new Room(room));
            }

            VentilationConsumption = floorToCopy.VentilationConsumption;
            LightConsumption = floorToCopy.LightConsumption;
            HardwareConsumption = floorToCopy.HardwareConsumption;
            OtherConsumption = floorToCopy.OtherConsumption;
            TotalConsumption = floorToCopy.TotalConsumption;
        }

        //[DataMember]
        //public List<WifiClient> Clients { get; set; }
    }
}