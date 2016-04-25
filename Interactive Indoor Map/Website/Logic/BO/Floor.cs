using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Website.Logic.BO.Utility;

namespace Website.Logic.BO
{
    public class Floor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int FloorLevel { get; set; }

        public string FloorName { get; set; }
    
        public List<Room> Rooms { get; set; }
    
        public double SurfaceArea { get; set; }

        public Endpoints Endpoints { get; set; }

        [NotMapped]
        public double Temperature
            =>
                (Rooms.Where(room => room.GetType() == typeof (SensorRoom))
                    .Cast<SensorRoom>()
                    .Sum(room => room.Temperature)/
            Rooms.Count(room => room.GetType() == typeof (SensorRoom)));

        [NotMapped]
        public double TemperatureMax => (Rooms.Where(room => room.GetType() == typeof(SensorRoom)).Cast<SensorRoom>().Sum(room => room.TemperatureMax) / Rooms.Count(room => room.GetType() == typeof(SensorRoom)));

        [NotMapped]
        public double TemperatureMin => (Rooms.Where(room => room.GetType() == typeof(SensorRoom))
                    .Cast<SensorRoom>()
                    .Sum(room => room.TemperatureMin) /
            Rooms.Count(room => room.GetType() == typeof(SensorRoom)));

        [NotMapped]
        public double CO2 => (Rooms.Where(room => room.GetType() == typeof(SensorRoom))
                    .Cast<SensorRoom>()
                    .Sum(room => room.CO2) /
            Rooms.Count(room => room.GetType() == typeof(SensorRoom)));

        [NotMapped]
        public double CO2Max => (Rooms.Where(room => room.GetType() == typeof(SensorRoom))
                    .Cast<SensorRoom>()
                    .Sum(room => room.CO2Max) /
            Rooms.Count(room => room.GetType() == typeof(SensorRoom)));

        [NotMapped]
        public double CO2Min => (Rooms.Where(room => room.GetType() == typeof(SensorRoom))
                    .Cast<SensorRoom>()
                    .Sum(room => room.CO2Min) /
            Rooms.Count(room => room.GetType() == typeof(SensorRoom)));

        [NotMapped]
        public int Light => (Rooms.Where(room => room.GetType() == typeof(SensorRoom)).Cast<SensorRoom>().Where(room => room.Light)).Count();

        [NotMapped]
        public double Lumen => (Rooms.Where(room => room.GetType() == typeof(SensorRoom))
                    .Cast<SensorRoom>()
                    .Sum(room => room.Lumen) / 
                    Convert.ToDouble(Rooms.Count(room => room.GetType() == typeof(SensorRoom))));

        [NotMapped]
        public double LumenMax => (Rooms.Where(room => room.GetType() == typeof(SensorRoom))
                    .Cast<SensorRoom>()
                    .Sum(room => room.LumenMax) / Convert.ToDouble(Rooms.Count(room => room.GetType() == typeof(SensorRoom))));
        
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
        public double HotWaterConsumption { get; set; }

        public double HotWaterConsumptionMax { get; set; }

        public double HotWaterConsumptionMin { get; set; }

        [NotMapped]
        public double ColdWaterConsumption { get; set; }

        public double ColdWaterConsumptionMax { get; set; }

        public double ColdWaterConsumptionMin { get; set; }

        [NotMapped]
        public int Motion => (Rooms.Where(room => room.GetType() == typeof(SensorRoom)).Cast<SensorRoom>().Where(room => room.Motion)).Count();

        [NotMapped]
        public int Occupants => (Rooms.Where(room => room.GetType() == typeof(SensorRoom)).Cast<SensorRoom>().Sum(room => room.Occupants));

        [NotMapped]
        public int WifiClients => (Rooms.Where(room => room.GetType() == typeof(SensorRoom)).Cast<SensorRoom>().Sum(room => room.WifiClients));

        [NotMapped]
        public double WifiClientsMax => (Rooms.Where(room => room.GetType() == typeof(SensorRoom)).Cast<SensorRoom>().Sum(room => room.WifiClientsMax));

        public Floor()
        {
            Rooms = new List<Room>();
        }

        public Floor(int floorLevel)
        {
            FloorLevel = floorLevel;
            Rooms = new List<Room>();
        }
    }
}