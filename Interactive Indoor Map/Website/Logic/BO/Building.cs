using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Website.Logic.BO.Utility;

namespace Website.Logic.BO
{
    public class Building
    {
        public List<Floor> Floors { get; set; }

        public Endpoints Endpoints { get; set; }


        [Key]
        public string Name { get; set; }

        public double SurfaceArea => Floors.Sum(floor => floor.SurfaceArea);

        public double NumberOfRooms => Floors.Sum(floor => floor.Rooms.Count);

        public double NumberOfSensorRoom => Floors.Sum(floor => floor.Rooms.Count(room => room.GetType() == typeof(SensorRoom)));

        [NotMapped]
        public double Temperature => (Floors.Sum(floor => floor.Rooms.Where(room => room.GetType() == typeof(SensorRoom)).Cast<SensorRoom>().Sum(room => room.Temperature)) / NumberOfSensorRoom);

        [NotMapped]
        public double TemperatureMax => (Floors.Sum(floor => floor.Rooms.Where(room => room.GetType() == typeof(SensorRoom)).Cast<SensorRoom>().Sum(room => room.TemperatureMax)) / NumberOfSensorRoom);

        [NotMapped]
        public double CO2 => (Floors.Sum(floor => floor.Rooms.Where(room => room.GetType() == typeof(SensorRoom)).Cast<SensorRoom>().Sum(room => room.CO2)) / NumberOfSensorRoom);

        [NotMapped]
        public double CO2Max => (Floors.Sum(floor => floor.Rooms.Where(room => room.GetType() == typeof(SensorRoom)).Cast<SensorRoom>().Sum(room => room.CO2Max)) / NumberOfSensorRoom);

        [NotMapped]
        public int Light => Floors.Sum(floor => floor.Light);

        [NotMapped]
        public double Lumen => (Floors.Sum(floor => floor.Rooms.Where(room => room.GetType() == typeof(SensorRoom)).Cast<SensorRoom>().Sum(room => room.Lumen)) / NumberOfSensorRoom);

        [NotMapped]
        public double LumenMax => (Floors.Sum(floor => floor.Rooms.Where(room => room.GetType() == typeof(SensorRoom)).Cast<SensorRoom>().Sum(room => room.LumenMax)) / NumberOfSensorRoom);

        [NotMapped]
        public double HardwareConsumption => Floors.Sum(floor => floor.HardwareConsumption);

        [NotMapped]
        public double HardwareConsumptionMax => Floors.Sum(floor => floor.HardwareConsumptionMax);

        [NotMapped]
        public double HardwareConsumptionMin => Floors.Sum(floor => floor.HardwareConsumptionMin);

        [NotMapped]
        public double LightConsumption => Floors.Sum(floor => floor.LightConsumption);

        [NotMapped]
        public double LightConsumptionMax => Floors.Sum(floor => floor.LightConsumptionMax);

        [NotMapped]
        public double LightConsumptionMin => Floors.Sum(floor => floor.LightConsumptionMin);

        [NotMapped]
        public double OtherConsumption => Floors.Sum(floor => floor.OtherConsumption);

        [NotMapped]
        public double OtherConsumptionMax => Floors.Sum(floor => floor.OtherConsumptionMax);

        [NotMapped]
        public double OtherConsumptionMin => Floors.Sum(floor => floor.OtherConsumptionMin);

        [NotMapped]
        public double VentilationConsumption => Floors.Sum(floor => floor.VentilationConsumption);

        [NotMapped]
        public double VentilationConsumptionMax => Floors.Sum(floor => floor.VentilationConsumptionMax);

        [NotMapped]
        public double VentilationConsumptionMin => Floors.Sum(floor => floor.VentilationConsumptionMin);

        [NotMapped]
        public double TotalPowerConsumption => VentilationConsumption + LightConsumption + HardwareConsumption + OtherConsumption;

        [NotMapped]
        public double TotalPowerConsumptionMax => VentilationConsumptionMax + LightConsumptionMax + HardwareConsumptionMax + OtherConsumptionMax;

        [NotMapped]
        public double TotalPowerConsumptionMin => VentilationConsumptionMin + LightConsumptionMin + HardwareConsumptionMin + OtherConsumptionMin;

        [NotMapped]
        public int Motion => Floors.Sum(floor => floor.Motion);

        [NotMapped]
        public int Occupants { get; set; }

        public int OccupantsMax { get; set; }

        [NotMapped]
        public int WifiClients => (Floors.Sum(floor => floor.Rooms.Where(room => room.GetType() == typeof(SensorRoom)).Cast<SensorRoom>().Sum(room => room.WifiClients)));

        [NotMapped]
        public int WifiClientsMax => (Floors.Sum(floor => floor.Rooms.Where(room => room.GetType() == typeof(SensorRoom)).Cast<SensorRoom>().Sum(room => room.WifiClientsMax)));

        [NotMapped]
        public double HotWaterConsumption => Floors.Sum(floor => floor.HotWaterConsumption);

        public double HotWaterConsumptionMax => Floors.Sum(floor => floor.HotWaterConsumptionMax);

        public double HotWaterConsumptionMin => Floors.Sum(floor => floor.HotWaterConsumptionMin);

        [NotMapped]
        public double ColdWaterConsumption => Floors.Sum(floor => floor.ColdWaterConsumption);

        public double ColdWaterConsumptionMax => Floors.Sum(floor => floor.ColdWaterConsumptionMax);

        public double ColdWaterConsumptionMin => Floors.Sum(floor => floor.ColdWaterConsumptionMin);

        public Building()
        {
            Floors = new List<Floor>();
        }
    }
}