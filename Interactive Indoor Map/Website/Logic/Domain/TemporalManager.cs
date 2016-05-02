using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.Logic.BO;
using Website.Logic.BO.Buildings;
using Website.Logic.BO.Floors;
using Website.Logic.BO.Rooms;

namespace Website.Logic.Domain
{
    public class TemporalManager
    {
        private SMapManagerTemporalt sMapManagerTemporal;
        public TemporalManager(SMapManagerTemporalt sMapManagerTemporal)
        {
            this.sMapManagerTemporal = sMapManagerTemporal;
        }

        private TemporalFloor GetTemporalFloor(LiveFloor liveFloor)
        {
            TemporalFloor floor = (TemporalFloor)liveFloor;

            List<Room> liveRooms = floor.Rooms.Where(room => room.GetType() == typeof (LiveRoom)).ToList();

            foreach (Room room in liveRooms)
            {
                floor.Rooms.Remove(room);
                TemporalRoom temporalRoom = GetTemporalRoom((LiveRoom)room);
                floor.Rooms.Add(temporalRoom);
            }
            return floor;
        }

        private TemporalRoom GetTemporalRoom(LiveRoom liveRoom)
        {
            TemporalRoom room = (TemporalRoom)liveRoom;
            return room;
        }

        private TemporalBuilding GetTemporalBuilding(LiveBuilding liveBuilding)
        {
            TemporalBuilding building = (TemporalBuilding)liveBuilding;
            List<Floor> liveFloors = building.Floors.Where(floor => floor.GetType() == typeof(LiveFloor)).ToList();

            foreach (Floor floor in liveFloors)
            {
                building.Floors.Remove(floor);
                TemporalFloor temporalFloor = GetTemporalFloor((LiveFloor)floor);
                building.Floors.Add(temporalFloor);
            }


            return building;
        }

        public TemporalBuilding GetTemporalBuildingReadings(LiveBuilding liveBuilding, DateTime timeFrom,
            DateTime timeTo)
        {
            TemporalBuilding building = GetTemporalBuilding(liveBuilding);
            sMapManagerTemporal.TemporalUpdateAll(building, timeFrom, timeTo);
            return building;
        }

        public TemporalFloor GetTemporalFloorReadings(LiveFloor liveFloor, DateTime timeFrom,
            DateTime timeTo)
        {
            TemporalFloor floor = GetTemporalFloor(liveFloor);
            sMapManagerTemporal.TemporalUpdateAll(floor, timeFrom, timeTo);
            return floor;
        }

        public TemporalRoom GetTemporalRoomReadings(LiveRoom liveRoom, DateTime timeFrom,
            DateTime timeTo)
        {
            TemporalRoom room = GetTemporalRoom(liveRoom);
            sMapManagerTemporal.TemporalUpdateAll(room, timeFrom, timeTo);
            return room;
        }

    }
}