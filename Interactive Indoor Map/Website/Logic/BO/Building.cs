using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Website.Logic.BO
{
    public class Building
    {

        public List<Floor> Floors { get; set; }
        
        [Key]
        public string Name { get; set; }

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
        public double HotWaterConsumption { get; set; }

        public double HotWaterConsumptionMax { get; set; }

        public double HotWaterConsumptionMin { get; set; }

        [NotMapped]
        public double ColdWaterConsumption { get; set; }

        public double ColdWaterConsumptionMax { get; set; }

        public double ColdWaterConsumptionMin { get; set; }

        public Building()
        {
            Floors = new List<Floor>();
        }
    }
}