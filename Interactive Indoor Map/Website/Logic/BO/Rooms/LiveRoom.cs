using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Website.Logic.BO.Utility;

namespace Website.Logic.BO.Rooms
{
    public class LiveRoom : SensorRoom
    {
        [NotMapped]
        public double Temperature { get; set; }

        [NotMapped]
        public int CO2 { get; set; }

        [NotMapped]
        public bool Light { get; set; }

        [NotMapped]
        public int Lumen { get; set; }

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
        public bool Motion { get; set; }

        [NotMapped]
        public int Occupants { get; set; }

        [NotMapped]
        public int WifiClients { get; set; }

        public LiveRoom() { }

        public LiveRoom(string name, Corners corners)
        {
            Name = name;
            Corners = corners;
            RoomType = RoomType.Classroom;
        }
    }
}