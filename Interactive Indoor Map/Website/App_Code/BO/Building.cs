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