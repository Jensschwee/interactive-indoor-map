using System.Collections.Generic;
using Website.Logic.BO;
using Website.Logic.BO.Buildings;
using Website.Logic.BO.Floors;
using Website.Logic.BO.Rooms;
using Website.Logic.BO.Utility;

namespace Website.DAL.Persistence
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BuildingDbContext : DbContext
    {
        public BuildingDbContext() : base("name=BuildingDbContext") {}

        public virtual DbSet<LiveBuilding> LiveBuildings { get; set; }
        public virtual DbSet<LiveFloor> LiveFloors { get; set; }
        //public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<LiveRoom> LiveRoom { get; set; }
        public virtual DbSet<SensorlessRoom> SensorlessRoom { get; set; }
        public virtual DbSet<Endpoints> Endpoints  { get; set; }
        public virtual DbSet<Coordinates> Coordinates { get; set; }
        public virtual DbSet<Corners> Corners { get; set; } 

    }
}
