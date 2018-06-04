using Microsoft.EntityFrameworkCore;
using vega.Models;
using Vega.Models;

namespace vega.Persistence
{
    public class VegaDbContext:DbContext
    {
        public DbSet<Make> Makes { get; set; }
        public DbSet<Feature> Features { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Photo> Photos { get; set; }
        public VegaDbContext(DbContextOptions<VegaDbContext> option)
        :base(option)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<VehicleFeature>().HasKey(vf=>new{vf.VehicleId,vf.FeatureId});
        }
        
    }
}