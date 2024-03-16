using CRUD_API_Second_Project.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUD_API_Second_Project.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) {
        
        }

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Post>().HasData(new Post()
            {
                Id = Guid.Parse("A6B2E063-F834-416E-A3D3-196BE16205AF"),
                Title = "This is title 1",
                Content = "This is content 1",
                Summary = "This is summary 1",
                UrlHandle = "Yes",
                FeaturedImageUrl = "https://images.unsplash.com/photo-1706026803368-d84389566a80?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHw1fHx8ZW58MHx8fHx8",
                Visible = true,
                Author = "BK",
                PublishDate = DateTime.Now,
                UpdateDate= DateTime.Now
            });
            
        }

    }
}
