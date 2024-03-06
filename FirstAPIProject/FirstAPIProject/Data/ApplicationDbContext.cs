using FirstAPIProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAPIProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) {


        }
         
        public DbSet<Villa> villas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa
                {
                    Id = 1,
                    Name = "ABC",
                    Details = "hello this is me",
                    ImageUrl = "",
                    Occupancy = 4,
                    Rate = 200,
                    Sqft = 200,
                    Amenity = "",
                    CreatedDate = DateTime.Now

                },
                new Villa
                {
                    Id = 2,
                    Name = "XYZ",
                    Details = "hello this is me other",
                    ImageUrl = "",
                    Occupancy = 40,
                    Rate = 2000,
                    Sqft = 2,
                    Amenity = "",
                    CreatedDate = DateTime.Now

                });  
        }
    }
}
