using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using Section_18_EntityFrameworkCore_PracticeCode.Models;

namespace Section_18_EntityFrameworkCore_PracticeCode.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Books> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().ToTable("Countries");
            modelBuilder.Entity<Person>().ToTable("Persons");

            //Seed to database
            string countriesJson = System.IO.File.ReadAllText("country.json");
            List<Country> countries = System.Text.Json.JsonSerializer.Deserialize<List<Country>>(countriesJson);
            foreach (Country country in countries)
                modelBuilder.Entity<Country>().HasData(country);

            //string personsJson = System.IO.File.ReadAllText("person.json");
            //List<Person> persons = System.Text.Json.JsonSerializer.Deserialize<List<Person>>(personsJson);
            //foreach(Person person in persons)
            //    modelBuilder.Entity<Person>().HasData(person);
            //modelBuilder.Entity<Country>().HasData(new Country()
            //{
            //    CountryID = Guid.NewGuid(),
            //    CountryName = "UK"
            //});

            modelBuilder.Entity<Books>().HasData(new Books()
            {
                Id = 1,
                Title = "Test 1",
                Description = "This is test 1",
            },
            new Books()
            {
                Id = 2,
                Title = "Test 2",
                Description = "This is test 2"
            });
        }

    }
}
