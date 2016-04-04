using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Website.Logic.BO;

namespace Website.Persistence
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
        }
        public Building GetBuilding(String buildingName)
        {
            using (BuildingDbContext context = new BuildingDbContext())
            {
                var building = context.Buildings.Where(b => b.Name == buildingName);
                return building.First();
            }
        }


    }
}