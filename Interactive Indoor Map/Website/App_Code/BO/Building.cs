using System;
using System.Collections.Generic;
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

        public int Light => Floors.Sum(floor => floor.Light);

        public double Lumen => (Floors.Sum(floor => floor.Rooms.Sum(room => room.Lumen)) / NumberOfRooms);

        public double LumenMax => (Floors.Sum(floor => floor.Rooms.Sum(room => room.LumenMax)) / NumberOfRooms);

        public int Motion => Floors.Sum(floor => floor.Motion);

        public double Temperature => (Floors.Sum(floor => floor.Rooms.Sum(room => room.Temperature)) / NumberOfRooms);

        public double TemperatureMax => (Floors.Sum(floor => floor.Rooms.Sum(room => room.TemperatureMax)) / NumberOfRooms);

        public double CO2 => (Floors.Sum(floor => floor.Rooms.Sum(room => room.CO2)) / NumberOfRooms);

        public double CO2Max => (Floors.Sum(floor => floor.Rooms.Sum(room => room.CO2Max)) / NumberOfRooms);

        public int Occupants { get; set; }

        public int OccupantsMax { get; set; }

        public double HardwareConsumption => Floors.Sum(floor => floor.HardwareConsumption);

        public double HardwareConsumptionMax => Floors.Sum(floor => floor.HardwareConsumptionMax);

        public double LightConsumption => Floors.Sum(floor => floor.LightConsumption);

        public double LightConsumptionMax => Floors.Sum(floor => floor.LightConsumptionMax);

        public double OtherConsumption => Floors.Sum(floor => floor.OtherConsumption);

        public double OtherConsumptionMax => Floors.Sum(floor => floor.OtherConsumptionMax);

        public double VentilationConsumption => Floors.Sum(floor => floor.VentilationConsumption);

        public double VentilationConsumptionMax => Floors.Sum(floor => floor.VentilationConsumptionMax);

        public double TotalPowerConsumption => VentilationConsumption + LightConsumption + HardwareConsumption + OtherConsumption;

        public double TotalPowerConsumptionMax => VentilationConsumptionMax + LightConsumptionMax + HardwareConsumptionMax + OtherConsumptionMax;

        public double HotWaterConsumption { get; set; }

        public double HotWaterConsumptionMax { get; set; }

        public double ColdWaterConsumption { get; set; }

        public double ColdWaterConsumptionMax { get; set; }
    }
}