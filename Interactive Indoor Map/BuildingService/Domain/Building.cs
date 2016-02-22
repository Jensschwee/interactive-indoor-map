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
        [DataMember]
        public List<Floor> Floors { get; set; }

        [DataMember]
        public string BuildingName { get; set; }

        [DataMember]
        public int? Occupants { get; set; }

        [DataMember]
        public double? VentilationConsumption
        {
            get { return Floors.Sum(floor => floor.VentilationConsumption); }
            set { VentilationConsumption = value; }
        }

        [DataMember]
        public double? LightConsumption
        {
            get { return Floors.Sum(floor => floor.LightConsumption); }
            set { LightConsumption = value; }
        }

        [DataMember]
        public double? HardwareConsumption
        {
            get { return Floors.Sum(floor => floor.HardwareConsumption); }
            set { HardwareConsumption = value; }
        }

        [DataMember]
        public double? OtherConsumption
        {
            get { return Floors.Sum(floor => floor.OtherConsumption); }
            set { OtherConsumption = value; }
        }

        [DataMember]
        public double? TotalPowerConsumption
        {
            get { return VentilationConsumption + LightConsumption + HardwareConsumption + OtherConsumption; }
            set { TotalPowerConsumption = value; }
        }

        [DataMember]
        public double? HotWaterConsumption { get; set; }

        [DataMember]
        public double? ColdWaterConsumption { get; set; }

        public Building() { }

        public Building(Building buildingToCopy)
        {
            foreach (var floor in buildingToCopy.Floors)
            {
                Floors.Add(new Floor(floor));
            }
            BuildingName = buildingToCopy.BuildingName;
            Occupants = buildingToCopy.Occupants;
            BuildingName = buildingToCopy.BuildingName;
            Occupants = buildingToCopy.Occupants;
            VentilationConsumption = buildingToCopy.VentilationConsumption;
            LightConsumption = buildingToCopy.LightConsumption;
            HardwareConsumption = buildingToCopy.HardwareConsumption;
            OtherConsumption = buildingToCopy.OtherConsumption;
            TotalPowerConsumption = buildingToCopy.TotalPowerConsumption;
        }

        public Building(Building buildingFloorToCopy, int floorLevel)
        {
            foreach (var floor in buildingFloorToCopy.Floors)
            {
                if (floor.FloorLevel == floorLevel)
                    Floors.Add(new Floor(floor));
            }

            BuildingName = buildingFloorToCopy.BuildingName;
            Occupants = buildingFloorToCopy.Occupants;
            VentilationConsumption = buildingFloorToCopy.VentilationConsumption;
            LightConsumption = buildingFloorToCopy.LightConsumption;
            HardwareConsumption = buildingFloorToCopy.HardwareConsumption;
            OtherConsumption = buildingFloorToCopy.OtherConsumption;
            TotalPowerConsumption = buildingFloorToCopy.TotalPowerConsumption;
        }


        //[DataMember]
        //public List<WifiClient> Clients { get; set; }

        //[DataMember]
        //public int WifiClients { get; set; }
    }
}