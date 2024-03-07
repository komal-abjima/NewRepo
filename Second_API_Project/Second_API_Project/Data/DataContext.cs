using Microsoft.EntityFrameworkCore;
using Second_API_Project.Entities;

namespace Second_API_Project.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
            
        }
        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
