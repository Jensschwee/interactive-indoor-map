using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.AccessControl;
using System.Web;
using Website.Domain;

namespace Website.BO
{
    public class Building
    {

        public Building()
        {
            Floors = new List<Floor>();
        }

        public List<Floor> Floors { get; set; }
        
        public string BuildingName { get; set; }

        public double SurfaceArea => Floors.Sum(floor => floor.SurfaceArea);

        public double NumberOfRooms => Floors.Sum(floor => floor.Rooms.Count);

        [NotMapped]
        public int Light => Floors.Sum(floor => floor.Light);

        [NotMapped]
        public double Lumen => (Floors.Sum(floor => floor.Rooms.Sum(room => room.Lumen)) / NumberOfRooms);

        [NotMapped]
        public double LumenMax => (Floors.Sum(floor => floor.Rooms.Sum(room => room.LumenMax)) / NumberOfRooms);

        [NotMapped]
        public int Motion => Floors.Sum(floor => floor.Motion);

        [NotMapped]
        public double Temperature => (Floors.Sum(floor => floor.Rooms.Sum(room => room.Temperature)) / NumberOfRooms);

        [NotMapped]
        public double TemperatureMax => (Floors.Sum(floor => floor.Rooms.Sum(room => room.TemperatureMax)) / NumberOfRooms);

        [NotMapped]
        public double CO2 => (Floors.Sum(floor => floor.Rooms.Sum(room => room.CO2)) / NumberOfRooms);

        [NotMapped]
        public double CO2Max => (Floors.Sum(floor => floor.Rooms.Sum(room => room.CO2Max)) / NumberOfRooms);

        [NotMapped]
        public int Occupants { get; set; }

        public int OccupantsMax { get; set; }

        [NotMapped]
        public double HardwareConsumption => Floors.Sum(floor => floor.HardwareConsumption);

        [NotMapped]
        public double HardwareConsumptionMax => Floors.Sum(floor => floor.HardwareConsumptionMax);

        [NotMapped]
        public double LightConsumption => Floors.Sum(floor => floor.LightConsumption);

        [NotMapped]
        public double LightConsumptionMax => Floors.Sum(floor => floor.LightConsumptionMax);

        public double OtherConsumption => Floors.Sum(floor => floor.OtherConsumption);

        [NotMapped]
        public double OtherConsumptionMax => Floors.Sum(floor => floor.OtherConsumptionMax);

        [NotMapped]
        public double VentilationConsumption => Floors.Sum(floor => floor.VentilationConsumption);

        [NotMapped]
        public double VentilationConsumptionMax => Floors.Sum(floor => floor.VentilationConsumptionMax);

        [NotMapped]
        public double TotalPowerConsumption => VentilationConsumption + LightConsumption + HardwareConsumption + OtherConsumption;

        [NotMapped]
        public double TotalPowerConsumptionMax => VentilationConsumptionMax + LightConsumptionMax + HardwareConsumptionMax + OtherConsumptionMax;

        [NotMapped]
        public double HotWaterConsumption { get; set; }

        public double HotWaterConsumptionMax { get; set; }

        [NotMapped]
        public double ColdWaterConsumption { get; set; }

        public double ColdWaterConsumptionMax { get; set; }
    }
}