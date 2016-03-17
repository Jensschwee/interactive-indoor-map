using System.Data.Entity;
using Website.Logic.BO;

namespace Website.Persistence
{

    public partial class BuildingDBContext : DbContext
    {
        public BuildingDBContext()
            : base("name=BuildingDBContext")
        {
        }

        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<Floor> Floors { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
    }
}
