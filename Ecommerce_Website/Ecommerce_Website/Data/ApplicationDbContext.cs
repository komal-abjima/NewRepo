using Ecommerce_Website.Models;
using Ecommerce_Website.Models.Employee_Mngmt_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Website.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Product> products { get; set; }

        public DbSet<UserModel> users { get; set; }

    }
}
