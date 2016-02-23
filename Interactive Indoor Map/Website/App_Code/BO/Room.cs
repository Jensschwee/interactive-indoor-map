using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.AccessControl;
using System.Web;
using Website.BO.Utility;

namespace Website.BO
{
    public class Room
    {
        public string RoomName { get; set; }

        public Area Area { get; set; }
        
        public bool IsLightActivated { get; set; }
        
        public int Lumen { get; set; }
        
        public bool IsMotionDetected { get; set; }
        
        public double Temperature { get; set; }
        
        public int CO2 { get; set; }
        
        public int Occupants { get; set; }
        
        public double VentilationConsumption { get; set; }
        
        public double LightConsumption { get; set; }
        
        public double HardwareConsumption { get; set; }
        
        public double OtherConsumption { get; set; }
        
        public double TotalConsumption
        {
            get { return VentilationConsumption + LightConsumption + HardwareConsumption + OtherConsumption; }
            set { TotalConsumption = value; }
        }

        public Room(string roomName, Area area)
        {
            RoomName = roomName;
            Area = area;
        }
    }
}