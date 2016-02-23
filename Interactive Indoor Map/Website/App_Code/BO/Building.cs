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
        
        public double VentilationConsumption
        {
            get { return Floors.Sum(floor => floor.VentilationConsumption); }
            set { VentilationConsumption = value; }
        }

        public double LightConsumption
        {
            get { return Floors.Sum(floor => floor.LightConsumption); }
            set { LightConsumption = value; }
        }
        
        public double HardwareConsumption
        {
            get { return Floors.Sum(floor => floor.HardwareConsumption); }
            set { HardwareConsumption = value; }
        }
        
        public double OtherConsumption
        {
            get { return Floors.Sum(floor => floor.OtherConsumption); }
            set { OtherConsumption = value; }
        }
        
        public double TotalPowerConsumption
        {
            get { return VentilationConsumption + LightConsumption + HardwareConsumption + OtherConsumption; }
            set { TotalPowerConsumption = value; }
        }
        
        public double HotWaterConsumption { get; set; }
        
        public double ColdWaterConsumption { get; set; }
    }
}