using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.AccessControl;
using System.Web;
using Website.BO;
using Website.BO.Utility;

namespace Website.BO
{
    public class Floor
    {
        public int FloorLevel { get; set; }
    
        public List<Room> Rooms { get; set; }
    
        public double SurfaceArea { get; set; }

        public int Light => (Rooms.Where(room => room.Light)).Count();

        public double Lumen => (Rooms.Sum(room => room.Lumen) / Convert.ToDouble(Rooms.Count));

        public double LumenMax => (Rooms.Sum(room => room.LumenMax) / Convert.ToDouble(Rooms.Count));

        public int Motion => (Rooms.Where(room => room.Motion)).Count();

        public double Temperature => (Rooms.Sum(room => room.Temperature) / Rooms.Count);

        public double TemperatureMax => (Rooms.Sum(room => room.TemperatureMax)/Rooms.Count);

        public double CO2 => (Rooms.Sum(room => room.CO2) / Convert.ToDouble(Rooms.Count));

        public double CO2Max => (Rooms.Sum(room => room.CO2Max)/ Convert.ToDouble(Rooms.Count));

        public double HardwareConsumption { get; set; }

        public double HardwareConsumptionMax { get; set; }

        public double LightConsumption { get; set; }

        public double LightConsumptionMax { get; set; }

        public double VentilationConsumption { get; set; }

        public double VentilationConsumptionMax { get; set; }

        public double OtherConsumption { get; set; }

        public double OtherConsumptionMax { get; set; }
    
        public double TotalPowerConsumption => VentilationConsumption + LightConsumption + HardwareConsumption + OtherConsumption;

        public double TotalPowerConsumptionMax => VentilationConsumptionMax + LightConsumptionMax + HardwareConsumptionMax + OtherConsumptionMax;

        public List<Sensor> Sensors { get; set; }

        public double HotWaterConsumption { get; set; }

        public double HotWaterConsumptionMax { get; set; }

        public double ColdWaterConsumption { get; set; }

        public double ColdWaterConsumptionMax { get; set; }

        public Floor(int floorLevel)
        {
            FloorLevel = floorLevel;
            Rooms = new List<Room>();
            Sensors = new List<Sensor>();
        }
    }
}