using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Website.Logic.BO.Utility;

namespace Website.Logic.BO.Rooms
{
    public abstract class SensorRoom : Room
    {
        public Endpoints Endpoints { get; set; }

        public Corners Corners { get; set; }

        public double SurfaceArea { get; set; }

        public double MaxTemperature = 30;
        public double MinTemperature = 5;

        public int MaxCO2 = 1500;
        public int MinCO2 = 200;
        
        public int MaxLux { get; set; }
        public int MinLux = 0;

        public double MaxHardwareConsumption { get; set; }
        public double MinHardwareConsumption = 0;

        public double MaxLightConsumption { get; set; }
        public double MinLightConsumption = 0;

        public double MaxVentilationConsumption { get; set; }
        public double MinVentilationConsumption = 0;

        public double MaxOtherConsumption { get; set; }
        public double MinOtherConsumption = 0;

        [NotMapped]
        public double TotalPowerConsumption { get; set; }

        [NotMapped]
        public double MaxTotalPowerConsumption => MaxVentilationConsumption + MaxLightConsumption + MaxHardwareConsumption + MaxOtherConsumption;

        [NotMapped]
        public double MinTotalPowerConsumption => MinVentilationConsumption + MinLightConsumption + MinHardwareConsumption + MinOtherConsumption;

        public int MaxOccupants { get; set; }
        public int MinOccupants = 0;

        public int MaxWifiClients { get; set; }
        public int MinWifiClients = 0;
    }
}