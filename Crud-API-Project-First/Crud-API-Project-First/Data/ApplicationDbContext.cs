using Crud_API_Project_First.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud_API_Project_First.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): 
            base(options){

        }
        public DbSet<SuperHerocs> superheroes { get; set; }
        
    }
}
