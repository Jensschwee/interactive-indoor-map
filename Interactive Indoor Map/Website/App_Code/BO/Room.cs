using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.AccessControl;
using System.Web;
using Website.BO.Utility;

namespace Website.BO
{
    public class Room
    {
        public string Name { get; set; }

        public string Alias { get; set; }

        public RoomType Type { get; set; }

        public Area Area { get; set; }

        public double SurfaceArea { get; set; }

        public bool Light { get; set; }
        
        public int Lumen { get; set; }

        public int LumenMax { get; set; }
        
        public bool Motion { get; set; }
        
        public double Temperature { get; set; }

        public double TemperatureMax { get; set; }
        
        public int CO2 { get; set; }

        public int CO2Max { get; set; }
        
        public int Occupants { get; set; }

        public int OccupantsMax { get; set; }
        
        public double VentilationConsumption { get; set; }

        public double VentilationConsumptionMax { get; set; }

        public double LightConsumption { get; set; }

        public double LightConsumptionMax { get; set; }

        public double HardwareConsumption { get; set; }
        
        public double HardwareConsumptionMax { get; set; }

        public double OtherConsumption { get; set; }

        public double OtherConsumptionMax { get; set; }

        public double TotalPowerConsumption => VentilationConsumption + LightConsumption + HardwareConsumption + OtherConsumption;

        public double TotalPowerConsumptionMax { get; set; }

        public Room(string name, Area area)
        {
            Name = name;
            Area = area;
        }
    }
}