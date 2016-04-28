using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Logic.BO.Floors
{
    public class TemporalFloor : Floor
    {
        public TemporalFloor()
        {
            Rooms = new List<Room>();
        }

        public TemporalFloor(int floorLevel)
        {
            FloorLevel = floorLevel;
            Rooms = new List<Room>();
        }
    }
}