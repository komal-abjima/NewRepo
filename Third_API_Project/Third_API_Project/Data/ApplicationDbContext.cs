using Microsoft.EntityFrameworkCore;
using Third_API_Project.Models;

namespace Third_API_Project.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) {
        
        }

        public ApplicationDbContext()
        {
            
        }

        public virtual DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<City>().HasData(new City()
            {
                CityID = Guid.Parse("C21C766C-70E3-452D-B9C4-703F86B364C3"), CityName = "Jaipur"
            });
            modelBuilder.Entity<City>().HasData(new City()
            {
                CityID = Guid.Parse("A6B2E063-F834-416E-A3D3-196BE16205AF"), CityName = "Jaisalmer"
            });
        }

    }
}
