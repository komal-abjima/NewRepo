using Ecommerce_Website.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Website.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Product> products { get; set; }

    }
}
