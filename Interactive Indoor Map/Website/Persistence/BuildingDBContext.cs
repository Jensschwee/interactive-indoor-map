using Website.Logic.BO;
using Website.Logic.BO.Utility;

namespace Website.Persistence
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BuildingDbContext : DbContext
    {
        public BuildingDbContext()
            : base("name=BuildingDbContext")
        {
        }

        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<Floor> Floors { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Area> Areas { get; set; }

        public virtual DbSet<Coordinates> Coordinates { get; set; }

        public virtual DbSet<Sensor> Sensors { get; set; }



    }
}
