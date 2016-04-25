using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Website.Logic.BO;
using Website.Logic.BO.Utility;

namespace Website.DAL.Persistence
{
    public class BuildingDAL
    {
        public void SaveBuilding(Building building)
        {
            using (BuildingDbContext context = new BuildingDbContext())
            {
                context.Buildings.AddOrUpdate(building);
                context.SaveChanges();
            }

            foreach (Floor floor in building.Floors)
            {
                //SaveFloor(floor);
            }
        }


        public Building GetBuilding(String buildingName)
        {
            using (BuildingDbContext context = new BuildingDbContext())
            {
                var tempBuilding = context.Buildings.Where(b => b.Name == buildingName)
                    .Include(b => b.SmapEndpoints)
                    .Include(b => b.Floors)
                    .Include(b => b.Floors.Select( f => f.SmapEndpoints))
                    .Include(b => b.Floors.Select(f => f.Rooms));
                return tempBuilding.First();
            }
        }


        public SensorRoom GetSensorRoom(int id)
        {
            using (BuildingDbContext context = new BuildingDbContext())
            {
                var tempRoom = context.Rooms.Where(r => r.Id == id).OfType<SensorRoom>()
                    .Include(r => r.Corners)
                    .Include(r => r.Corners.BottomLeftCorner)
                    .Include(r => r.Corners.BottomRightCorner)
                    .Include(r => r.Corners.TopLeftCorner)
                    .Include(r => r.Corners.TopRightCorner)
                    .Include(r => r.SmapEndpoints);
                return tempRoom.First();
            }
        }

        public SensorlessRoom GetSensorLessRoom(int id)
        {
            using (BuildingDbContext context = new BuildingDbContext())
            {
                var tempRoom = context.Rooms.Where(r => r.Id == id).OfType<SensorlessRoom>()
                    .Include(r => r.Coordinates);
                return tempRoom.First();
            }
        }


        private void SaveFloor(Floor floor)
        {
            using (BuildingDbContext context = new BuildingDbContext())
            {
                context.Floors.AddOrUpdate(floor);
                context.SaveChanges();
            }

            foreach (Room room in floor.Rooms)
            {
                if (room.GetType() == typeof(SensorRoom))
                {
                    SaveSensorRoom((SensorRoom)room);
                }
                else if (room.GetType() == typeof(SensorlessRoom))
                {
                    SaveSensorlessRoom((SensorlessRoom)room);
                }
            }

        }


        private void SaveSensorlessRoom(SensorlessRoom sensorlessRoom)
        {
            using (BuildingDbContext context = new BuildingDbContext())
            {
                context.SensorlessRoom.AddOrUpdate(sensorlessRoom);
                context.SaveChanges();
            }

            foreach (Coordinates coordinates in sensorlessRoom.Coordinates)
            {
                SaveCoordinates(coordinates);
            }
        }

        private void SaveSensorRoom(SensorRoom sensorRoom)
        {
            using (BuildingDbContext context = new BuildingDbContext())
            {
                context.SensorRoom.AddOrUpdate(sensorRoom);
                context.SaveChanges();
            }
            SaveCorners(sensorRoom.Corners);
            if (sensorRoom.SmapEndpoints != null)
                SaveSmapEndpoints(sensorRoom.SmapEndpoints);
        }

        private void SaveCoordinates(Coordinates coordinates)
        {
            using (BuildingDbContext context = new BuildingDbContext())
            {
                context.Coordinates.AddOrUpdate(coordinates);
                context.SaveChanges();
            }
        }

        private void SaveCorners(Corners corners)
        {
            using (BuildingDbContext context = new BuildingDbContext())
            {
                context.Corners.AddOrUpdate(corners);
                context.SaveChanges();
            }
        }

        private void SaveSmapEndpoints(SmapEndpoints smapEndpoints)
        {
            using (BuildingDbContext context = new BuildingDbContext())
            {
                context.SmapEndpoints.AddOrUpdate(smapEndpoints);
                context.SaveChanges();
            }
        }




    }
}