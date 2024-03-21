using Microsoft.EntityFrameworkCore;
using Payment_Detail_Registration.Models;

namespace Payment_Detail_Registration.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<PaymentDetail> PaymentDetails { get; set; }
    }
}
