using Microsoft.EntityFrameworkCore;
using Music_Management_System.Models;

namespace Music_Management_System.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
        
        
        }

        public DbSet<Music> music { get; set; }

      
    }
}
