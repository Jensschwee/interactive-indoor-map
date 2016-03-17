using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Website.Logic.BO.Utility;

namespace Website.Logic.BO
{
    public class Room
    {
        [Key]
        public string Name { get; set; }

        public string Alias { get; set; }

        public RoomType Type { get; set; }

        public Area Area { get; set; }

        public double SurfaceArea { get; set; }

        [NotMapped]
        public bool Light { get; set; }

        [NotMapped]
        public int Lumen { get; set; }

        public int LumenMax { get; set; }

        [NotMapped]
        public bool Motion { get; set; }

        [NotMapped]
        public double Temperature { get; set; }

        public double TemperatureMax { get; set; }

        [NotMapped]
        public int CO2 { get; set; }

        public int CO2Max { get; set; }

        [NotMapped]
        public int Occupants { get; set; }

        public int OccupantsMax { get; set; }

        [NotMapped]
        public double VentilationConsumption { get; set; }

        [NotMapped]
        public double VentilationConsumptionMax { get; set; }

        [NotMapped]
        public double LightConsumption { get; set; }
        
        public double LightConsumptionMax { get; set; }

        [NotMapped]
        public double HardwareConsumption { get; set; }
        
        public double HardwareConsumptionMax { get; set; }

        [NotMapped]
        public double OtherConsumption { get; set; }

        public double OtherConsumptionMax { get; set; }

        [NotMapped]
        public double TotalPowerConsumption => VentilationConsumption + LightConsumption + HardwareConsumption + OtherConsumption;

        public double TotalPowerConsumptionMax => VentilationConsumptionMax + LightConsumptionMax + HardwareConsumptionMax + OtherConsumptionMax;

        public Room() { }

        public Room(string name, Area area)
        {
            Name = name;
            Area = area;
        }
    }

    public enum RoomType
    {
        Corridor, Classroom, Grouproom, Office, Toilet, Utilityroom
    }
}