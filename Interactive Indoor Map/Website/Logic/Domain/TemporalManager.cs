using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.Logic.BO;
using Website.Logic.BO.Floors;
using Website.Logic.BO.Rooms;

namespace Website.Logic.Domain
{
    public class TemporalManager
    {

        public TemporalFloor GetTemporalFloor(LiveFloor liveFloor, DateTime timeFrom, DateTime timeTo)
        {
            TemporalFloor floor = (TemporalFloor)liveFloor;

            List<Room> liveRooms = floor.Rooms.Where(room => room.GetType() == typeof (LiveRoom)).ToList();

            foreach (Room room in liveRooms)
            {
                floor.Rooms.Remove(room);
                TemporalRoom temporalRoom = (TemporalRoom) room;

                floor.Rooms.Add(temporalRoom);
            }

            return floor;

        }

    }
}