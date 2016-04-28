using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Website.Logic.BO.Floors;
using Website.Logic.BO.Rooms;
using Website.Logic.BO.Utility;

namespace Website.Logic.BO
{
    public abstract class Building
    {
        public List<Floor> Floors { get; set; }

        public Endpoints Endpoints { get; set; }

        [Key]
        public string Name { get; set; }

        [NotMapped]
        public double SurfaceArea => Floors.Sum(floor => floor.SurfaceArea);

        [NotMapped]
        public double NumberOfRooms => Floors.Sum(floor => floor.Rooms.Count);

        [NotMapped]
        public double NumberOfLiveRoom => Floors.Sum(floor => floor.Rooms.Count(room => room.GetType() == typeof(LiveRoom)));

        [NotMapped]
        public double TemperatureMax => (Floors.Sum(floor => floor.Rooms.Where(room => room.GetType() == typeof(LiveRoom)).Cast<LiveRoom>().Sum(room => room.MaxTemperature)) / NumberOfLiveRoom);

        [NotMapped]
        public double CO2Max => (Floors.Sum(floor => floor.Rooms.Where(room => room.GetType() == typeof(LiveRoom)).Cast<LiveRoom>().Sum(room => room.MaxCO2)) / NumberOfLiveRoom);
        
        [NotMapped]
        public double LumenMax => (Floors.Sum(floor => floor.Rooms.Where(room => room.GetType() == typeof(LiveRoom)).Cast<LiveRoom>().Sum(room => room.MaxLumen)) / NumberOfLiveRoom);
        
        [NotMapped]
        public double HardwareConsumptionMax => Floors.Sum(floor => floor.MaxHardwareConsumption);

        [NotMapped]
        public double HardwareConsumptionMin => Floors.Sum(floor => floor.MinHardwareConsumption);

        [NotMapped]
        public double LightConsumptionMax => Floors.Sum(floor => floor.MaxLightConsumption);

        [NotMapped]
        public double LightConsumptionMin => Floors.Sum(floor => floor.MinLightConsumption);

        [NotMapped]
        public double OtherConsumptionMax => Floors.Sum(floor => floor.OtherConsumptionMax);

        [NotMapped]
        public double OtherConsumptionMin => Floors.Sum(floor => floor.OtherConsumptionMin);
        
        [NotMapped]
        public double VentilationConsumptionMax => Floors.Sum(floor => floor.MaxVentilationConsumption);

        [NotMapped]
        public double VentilationConsumptionMin => Floors.Sum(floor => floor.MinVentilationConsumption);

        
        [NotMapped]
        public double TotalPowerConsumptionMax => VentilationConsumptionMax + LightConsumptionMax + HardwareConsumptionMax + OtherConsumptionMax;

        [NotMapped]
        public double TotalPowerConsumptionMin => VentilationConsumptionMin + LightConsumptionMin + HardwareConsumptionMin + OtherConsumptionMin;

        public int OccupantsMax { get; set; }
        
        [NotMapped]
        public int WifiClientsMax => (Floors.Sum(floor => floor.Rooms.Where(room => room.GetType() == typeof(LiveRoom)).Cast<LiveRoom>().Sum(room => room.MaxWifiClients)));

        [NotMapped]
        public double HotWaterConsumptionMax => Floors.Sum(floor => floor.MaxHotWaterConsumption);
        public double HotWaterConsumptionMin => Floors.Sum(floor => floor.MinHotWaterConsumption);

        [NotMapped]
        public double ColdWaterConsumptionMax => Floors.Sum(floor => floor.MaxColdWaterConsumption);
        public double ColdWaterConsumptionMin => Floors.Sum(floor => floor.MinColdWaterConsumption);
    }
}