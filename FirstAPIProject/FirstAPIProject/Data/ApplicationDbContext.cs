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
                    ImageUrl = "https://plus.unsplash.com/premium_photo-1709311441238-1c83ef3b8d04?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHwyfHx8ZW58MHx8fHx8",
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
                    Details = "hello this is me XYZ",
                    ImageUrl = "https://plus.unsplash.com/premium_photo-1709311441238-1c83ef3b8d04?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHwyfHx8ZW58MHx8fHx8",
                    Occupancy = 40,
                    Rate = 2000,
                    Sqft = 2,
                    Amenity = "",
                    CreatedDate = DateTime.Now

                },
                new Villa
                {
                    Id = 3,
                    Name = "John",
                    Details = "hello this is me John",
                    ImageUrl = "https://plus.unsplash.com/premium_photo-1709311441238-1c83ef3b8d04?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHwyfHx8ZW58MHx8fHx8",
                    Occupancy = 400,
                    Rate = 20000,
                    Sqft = 20,
                    Amenity = "",
                    CreatedDate = DateTime.Now

                });  
        }
    }
}
