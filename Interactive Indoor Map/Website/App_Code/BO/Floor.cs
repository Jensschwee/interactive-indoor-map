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
    
        public double VentilationConsumption { get; set; }
    
        public double LightConsumption { get; set; }
    
        public double HardwareConsumption { get; set; }

        public double SurfaceArea => Rooms.Sum(room => room.SurfaceArea);

        public int IsLightActivated => (Rooms.Where(room => room.IsLightActivated)).Count();

        public double Lumen => (Rooms.Sum(room => room.Lumen) / Rooms.Count);

        public int IsMotionDetected => (Rooms.Where(room => room.IsMotionDetected)).Count();

        public double Temperature => (Rooms.Sum(room => room.Temperature) / Rooms.Count);

        public double CO2 => (Rooms.Sum(room => room.CO2) / Rooms.Count);

        public double OtherConsumption { get; set; }
    
        public double TotalPowerConsumption => VentilationConsumption + LightConsumption + HardwareConsumption + OtherConsumption;

        public List<Sensor> Sensors { get; set; }

        public double HotWaterConsumption { get; set; }

        public double ColdWaterConsumption { get; set; }

        public Floor(int floorLevel)
        {
            FloorLevel = floorLevel;
            Rooms = new List<Room>();
            Sensors = new List<Sensor>();
        }
    }
}