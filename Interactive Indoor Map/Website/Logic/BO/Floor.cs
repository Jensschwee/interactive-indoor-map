using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Website.Logic.BO.Utility;

namespace Website.Logic.BO
{
    public class Floor
    {
        public int FloorLevel { get; set; }
    
        public List<Room> Rooms { get; set; }
    
        public double SurfaceArea { get; set; }

        [NotMapped]
        public int Light => (Rooms.Where(room => room.Light)).Count();

        [NotMapped]
        public double Lumen => (Rooms.Sum(room => room.Lumen) / Convert.ToDouble(Rooms.Count));

        [NotMapped]
        public double LumenMax => (Rooms.Sum(room => room.LumenMax) / Convert.ToDouble(Rooms.Count));

        [NotMapped]
        public int Motion => (Rooms.Where(room => room.Motion)).Count();

        [NotMapped]
        public double Temperature => (Rooms.Sum(room => room.Temperature) / Rooms.Count);

        [NotMapped]
        public double TemperatureMax => (Rooms.Sum(room => room.TemperatureMax)/Rooms.Count);

        [NotMapped]
        public double CO2 => (Rooms.Sum(room => room.CO2) / Convert.ToDouble(Rooms.Count));

        [NotMapped]
        public double CO2Max => (Rooms.Sum(room => room.CO2Max)/ Convert.ToDouble(Rooms.Count));

        [NotMapped]
        public double HardwareConsumption { get; set; }

        public double HardwareConsumptionMax { get; set; }

        [NotMapped]
        public double LightConsumption { get; set; }

        public double LightConsumptionMax { get; set; }

        [NotMapped]
        public double VentilationConsumption { get; set; }

        public double VentilationConsumptionMax { get; set; }

        [NotMapped]
        public double OtherConsumption { get; set; }

        public double OtherConsumptionMax { get; set; }

        [NotMapped]
        public double TotalPowerConsumption => VentilationConsumption + LightConsumption + HardwareConsumption + OtherConsumption;

        [NotMapped]
        public double TotalPowerConsumptionMax => VentilationConsumptionMax + LightConsumptionMax + HardwareConsumptionMax + OtherConsumptionMax;

        public List<Sensor> Sensors { get; set; }

        [NotMapped]
        public double HotWaterConsumption { get; set; }

        public double HotWaterConsumptionMax { get; set; }

        [NotMapped]
        public double ColdWaterConsumption { get; set; }

        public double ColdWaterConsumptionMax { get; set; }

        public Floor() { }

        public Floor(int floorLevel)
        {
            FloorLevel = floorLevel;
            Rooms = new List<Room>();
            Sensors = new List<Sensor>();
        }
    }
}