using Crud_API_Project_First.Data;
using Crud_API_Project_First.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Crud_API_Project_First.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public SuperHeroController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<ActionResult<List<SuperHerocs>>> Get()
        {
            return Ok(await _db.superheroes.ToListAsync());
            //return new List<SuperHerocs>
            //{
            //    //new SuperHerocs
            //    //{
            //    //    Name ="Spider man",
            //    //    FirstName = "John",
            //    //    LastName = "Smith",
            //    //    Place = "Uk"
            //    //}

            //};
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHerocs>>> Post(SuperHerocs hero)
        {
            _db.superheroes.Add(hero);
            await _db.SaveChangesAsync();

            return Ok(await _db.superheroes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHerocs>>> Update(SuperHerocs hero)
        {
            var dbhero = await _db.superheroes.FindAsync(hero.Id);
            if(dbhero == null)
            {
                return BadRequest("It is not found");
            }
            dbhero.Name = hero.Name;
            dbhero.FirstName = hero.FirstName;
            dbhero.LastName = hero.LastName;
            dbhero.Place = hero.Place;

            await _db.SaveChangesAsync();
            return Ok(await _db.superheroes.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHerocs>>> Delete(int id)
        {
            var dbHero = await _db.superheroes.FindAsync(id);
            if( dbHero == null)
            {
                return BadRequest("Hero not found");
            }
            _db.superheroes.Remove(dbHero);
            await _db.SaveChangesAsync();

            return Ok(await _db.superheroes.ToListAsync());
        }
    }
}






