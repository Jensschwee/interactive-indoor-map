using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Website.Logic.BO.Utility;

namespace Website.Logic.BO
{
    public class SensorRoom : Room
    {
        public Endpoints Endpoints { get; set; }

        public Corners Corners { get; set; }

        public double SurfaceArea { get; set; }

        [NotMapped]
        public double Temperature { get; set; }

        public double TemperatureMax { get; set; }

        public double TemperatureMin { get; set; }

        [NotMapped]
        public int CO2 { get; set; }

        public int CO2Max { get; set; }

        public int CO2Min { get; set; }

        [NotMapped]
        public bool Light { get; set; }

        [NotMapped]
        public int Lumen { get; set; }

        public int LumenMax { get; set; }

        [NotMapped]
        public double HardwareConsumption { get; set; }

        public double HardwareConsumptionMax { get; set; }

        public double HardwareConsumptionMin { get; set; }

        [NotMapped]
        public double LightConsumption { get; set; }
        
        public double LightConsumptionMax { get; set; }

        public double LightConsumptionMin { get; set; }

        [NotMapped]
        public double VentilationConsumption { get; set; }

        public double VentilationConsumptionMax { get; set; }

        public double VentilationConsumptionMin { get; set; }

        [NotMapped]
        public double OtherConsumption { get; set; }

        public double OtherConsumptionMax { get; set; }

        public double OtherConsumptionMin { get; set; }

        [NotMapped]
        public double TotalPowerConsumption => VentilationConsumption + LightConsumption + HardwareConsumption + OtherConsumption;

        [NotMapped]
        public double TotalPowerConsumptionMax => VentilationConsumptionMax + LightConsumptionMax + HardwareConsumptionMax + OtherConsumptionMax;

        [NotMapped]
        public double TotalPowerConsumptionMin => VentilationConsumptionMin + LightConsumptionMin + HardwareConsumptionMin + OtherConsumptionMin;

        [NotMapped]
        public bool Motion { get; set; }

        [NotMapped]
        public int Occupants { get; set; }

        public int OccupantsMax { get; set; }

        [NotMapped]
        public int WifiClients { get; set; }

        public int WifiClientsMax { get; set; }

        public SensorRoom() { }

        public SensorRoom(string name, Corners corners)
        {
            Name = name;
            Corners = corners;
            RoomType = RoomType.Classroom;
        }
    }
}