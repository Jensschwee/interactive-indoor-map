using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Website.Logic.BO.Rooms;
using Website.Logic.BO.Utility;

namespace Website.Logic.BO
{
    public abstract class Floor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int FloorLevel { get; set; }

        public string FloorName { get; set; }

        [NotMapped]
        public double NumberOfSensorRooms => Rooms.Count(room => room.GetType().IsSubclassOf(typeof(SensorRoom)));

        public virtual List<Room> Rooms { get; set; }
    
        public double SurfaceArea { get; set; }

        public Endpoints Endpoints { get; set; }

        [NotMapped]
        public double MaxTemperature => (
            Rooms.Where(room => room.GetType() == typeof(LiveRoom)).
            Cast<LiveRoom>().
            Sum(room => room.MaxTemperature) / Convert.ToDouble(NumberOfSensorRooms));

        [NotMapped]
        public double MinTemperature => (Rooms.Where(room => room.GetType() == typeof(LiveRoom))
                    .Cast<LiveRoom>()
                    .Sum(room => room.MinTemperature) / Convert.ToDouble(NumberOfSensorRooms));

        [NotMapped]
        public double MaxCO2 => (Rooms.Where(room => room.GetType() == typeof(LiveRoom))
                    .Cast<LiveRoom>()
                    .Sum(room => room.MaxCO2) / Convert.ToDouble(NumberOfSensorRooms));

        [NotMapped]
        public double MinCO2 => (Rooms.Where(room => room.GetType() == typeof(LiveRoom))
                    .Cast<LiveRoom>()
                    .Sum(room => room.MinCO2) / Convert.ToDouble(NumberOfSensorRooms));

        [NotMapped]
        public double MaxLux => (Rooms.Where(room => room.GetType() == typeof(LiveRoom))
                    .Cast<LiveRoom>()
                    .Sum(room => room.MaxLux) / Convert.ToDouble(NumberOfSensorRooms));

        public double MinLux = 0;

        public double MaxHardwareConsumption { get; set; }
        public double MinHardwareConsumption = 0;

        public double MaxLightConsumption { get; set; }
        public double MinLightConsumption = 0;


        public double MaxVentilationConsumption { get; set; }
        public double MinVentilationConsumption = 0;

        public double MaxOtherConsumption { get; set; }
        public double MinOtherConsumption = 0;

        [NotMapped]
        public double MaxTotalPowerConsumption => 
            MaxVentilationConsumption + MaxLightConsumption + MaxHardwareConsumption + MaxOtherConsumption;

        [NotMapped]
        public double MinTotalPowerConsumption => 
            MinVentilationConsumption + MinLightConsumption + MinHardwareConsumption + MinOtherConsumption;

        public double MaxOccupants => (Rooms.
            Where(room => room.GetType() == typeof(LiveRoom)).
            Cast<LiveRoom>().
            Sum(room => room.MaxOccupants));

        public double MaxHotWaterConsumption { get; set; }
        public double MinHotWaterConsumption = 0;

        public double MaxColdWaterConsumption { get; set; }
        public double MinColdWaterConsumption = 0;

        [NotMapped]
        public int MaxWifiClients => Rooms.
            Where(room => room.GetType() == typeof(LiveRoom)).
            Cast<LiveRoom>().
            Sum(room => room.MaxWifiClients);
    }
}