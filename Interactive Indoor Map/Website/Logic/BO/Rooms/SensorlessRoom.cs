using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.Logic.BO.Rooms;
using Website.Logic.BO.Utility;

namespace Website.Logic.BO.Rooms
{
    public class SensorlessRoom : Room
    {
        public List<Coordinates> Coordinates { get; set; }

        public SensorlessRoom() { }

        public SensorlessRoom(string name, List<Coordinates> coordinates )
        {
            Name = name;
            Coordinates = coordinates;
        }
    }
}