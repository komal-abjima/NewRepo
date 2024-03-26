using Employee_Mngmt_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Mngmt_Project.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
        
        
        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<Employee> employee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("employee");
            modelBuilder.Entity<UserModel>().ToTable("Users");
        }

    }
}
