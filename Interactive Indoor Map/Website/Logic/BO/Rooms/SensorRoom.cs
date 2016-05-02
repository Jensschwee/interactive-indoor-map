using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Website.Logic.BO.Utility;

namespace Website.Logic.BO
{
    public abstract class SensorRoom : Room
    {
        public Endpoints Endpoints { get; set; }

        public Corners Corners { get; set; }

        public double SurfaceArea { get; set; }
        
        public double MaxTemperature { get; set; }
        public double MinTemperature = 15;

        public int MaxCO2 { get; set; }
        public int MinCO2 = 0;
        
        public int MaxLumen { get; set; }
        public int MinLumen = 0;

        public double MaxHardwareConsumption { get; set; }
        public double MinHardwareConsumption = 0;

        public double MaxLightConsumption { get; set; }
        public double MinLightConsumption = 0;

        public double MaxVentilationConsumption { get; set; }
        public double MinVentilationConsumption = 0;

        public double MaxOtherConsumption { get; set; }
        public double MinOtherConsumption = 0;

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