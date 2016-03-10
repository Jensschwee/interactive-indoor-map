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

        public int IsLightActivated => Floors.Sum(floor => floor.IsLightActivated);

        public double Lumen => (Floors.Sum(floor => floor.Rooms.Sum(room => room.Lumen)) / Floors.Sum(floor => floor.Rooms.Count));

        public int IsMotionDetected => Floors.Sum(floor => floor.IsMotionDetected);

        public double Temperature => (Floors.Sum(floor => floor.Rooms.Sum(room => room.Temperature)) / Floors.Sum(floor => floor.Rooms.Count));

        public double CO2 => (Floors.Sum(floor => floor.Rooms.Sum(room => room.CO2)) / Floors.Sum(floor => floor.Rooms.Count));

        public int Occupants { get; set; }
        
        public double VentilationConsumption => Floors.Sum(floor => floor.VentilationConsumption);

        public double LightConsumption => Floors.Sum(floor => floor.LightConsumption);

        public double HardwareConsumption => Floors.Sum(floor => floor.HardwareConsumption);

        public double OtherConsumption => Floors.Sum(floor => floor.OtherConsumption);

        public double TotalPowerConsumption => VentilationConsumption + LightConsumption + HardwareConsumption + OtherConsumption;

        public double HotWaterConsumption { get; set; }
        
        public double ColdWaterConsumption { get; set; }
    }
}