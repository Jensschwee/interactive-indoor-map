using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Website.Logic.BO.Rooms;

namespace Website.Logic.BO.Floors
{
    public class LiveFloor : Floor
    {

        

        [NotMapped]
        public double Temperature
            =>
                (Rooms.Where(room => room.GetType() == typeof(LiveRoom))
                    .Cast<LiveRoom>()
                    .Sum(room => room.Temperature) /
            Rooms.Count(room => room.GetType() == typeof(LiveRoom)));

        [NotMapped]
        public double CO2 => (Rooms.Where(room => room.GetType() == typeof(LiveRoom))
                    .Cast<LiveRoom>()
                    .Sum(room => room.CO2) /
            Rooms.Count(room => room.GetType() == typeof(LiveRoom)));

        [NotMapped]
        public int Light => (Rooms.Where(room => room.GetType() == typeof(LiveRoom)).Cast<LiveRoom>().Where(room => room.Light)).Count();

        [NotMapped]
        public double Lumen => (Rooms.Where(room => room.GetType() == typeof(LiveRoom))
                    .Cast<LiveRoom>()
                    .Sum(room => room.Lumen) /
                    Convert.ToDouble(Rooms.Count(room => room.GetType() == typeof(LiveRoom))));

        [NotMapped]
        public double HardwareConsumption { get; set; }

        [NotMapped]
        public double LightConsumption { get; set; }

        [NotMapped]
        public double VentilationConsumption { get; set; }

        [NotMapped]
        public double OtherConsumption { get; set; }

        [NotMapped]
        public double TotalPowerConsumption { get; set; }

        [NotMapped]
        public double HotWaterConsumption { get; set; }

        [NotMapped]
        public int Motion => (Rooms.Where(room => room.GetType() == typeof(LiveRoom)).Cast<LiveRoom>().Where(room => room.Motion)).Count();

        [NotMapped]
        public int Occupants => (Rooms.Where(room => room.GetType() == typeof(LiveRoom)).Cast<LiveRoom>().Sum(room => room.Occupants));

        [NotMapped]
        public int WifiClients => (Rooms.Where(room => room.GetType() == typeof(LiveRoom)).Cast<LiveRoom>().Sum(room => room.WifiClients));

        [NotMapped]
        public double ColdWaterConsumption { get; set; }

        public LiveFloor()
        {
            Rooms = new List<Room>();
        }

        public LiveFloor(int floorLevel)
        {
            FloorLevel = floorLevel;
            Rooms = new List<Room>();
        }
    }
}