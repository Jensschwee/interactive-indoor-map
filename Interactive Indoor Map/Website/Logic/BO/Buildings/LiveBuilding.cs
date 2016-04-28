using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Website.Logic.BO.Floors;
using Website.Logic.BO.Rooms;

namespace Website.Logic.BO.Buildings
{
    public class LiveBuilding : Building
    {

        [NotMapped]
        public double Temperature => (Floors.Sum(floor => floor.Rooms.Where(room => room.GetType() == typeof(LiveRoom)).Cast<LiveRoom>().Sum(room => room.Temperature)) / NumberOfLiveRoom);

        [NotMapped]
        public double CO2 => (Floors.Sum(floor => floor.Rooms.Where(room => room.GetType() == typeof(LiveRoom)).Cast<LiveRoom>().Sum(room => room.CO2)) / NumberOfLiveRoom);

        [NotMapped]
        public int Light => Floors.Where(floor => floor.GetType() == typeof(LiveFloor)).Cast<LiveFloor>().Sum(floor => floor.Light);

        [NotMapped]
        public double Lumen => (Floors.Sum(floor => floor.Rooms.Where(room => room.GetType() == typeof(LiveRoom)).Cast<LiveRoom>().Sum(room => room.Lumen)) / NumberOfLiveRoom);

        [NotMapped]
        public double HardwareConsumption => Floors.Where(floor => floor.GetType() == typeof(LiveFloor)).Cast<LiveFloor>().Sum(floor => floor.HardwareConsumption);

        [NotMapped]
        public double LightConsumption => Floors.Where(floor => floor.GetType() == typeof(LiveFloor)).Cast<LiveFloor>().Sum(floor => floor.LightConsumption);

        [NotMapped]
        public double OtherConsumption => Floors.Where(floor => floor.GetType() == typeof(LiveFloor)).Cast<LiveFloor>().Sum(floor => floor.OtherConsumption);

        [NotMapped]
        public double VentilationConsumption => Floors.Where(floor => floor.GetType() == typeof(LiveFloor)).Cast<LiveFloor>().Sum(floor => floor.VentilationConsumption);

        [NotMapped]
        public double TotalPowerConsumption => VentilationConsumption + LightConsumption + HardwareConsumption + OtherConsumption;

        [NotMapped]
        public int Motion => Floors.Where(floor => floor.GetType() == typeof(LiveFloor)).Cast<LiveFloor>().Sum(floor => floor.Motion);


        [NotMapped]
        public int Occupants { get; set; }

        [NotMapped]
        public int WifiClients => (Floors.Sum(floor => floor.Rooms.Where(room => room.GetType() == typeof(LiveRoom)).Cast<LiveRoom>().Sum(room => room.WifiClients)));

        [NotMapped]
        public double HotWaterConsumption => Floors.Where(floor => floor.GetType() == typeof(LiveFloor)).Cast<LiveFloor>().Sum(floor => floor.HotWaterConsumption);

        [NotMapped]
        public double ColdWaterConsumption => Floors.Where(floor => floor.GetType() == typeof(LiveFloor)).Cast<LiveFloor>().Sum(floor => floor.ColdWaterConsumption);


        public LiveBuilding()
        {
            Floors = new List<Floor>();
        }
    }
}