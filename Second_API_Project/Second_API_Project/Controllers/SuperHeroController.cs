using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Second_API_Project.Data;
using Second_API_Project.Entities;

namespace Second_API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext _db;
        public SuperHeroController(DataContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            var heroes = await _db.SuperHeroes.ToListAsync();
            return Ok(heroes);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetHeroesByID(int id)
        {
            var hero = await _db.SuperHeroes.FindAsync(id);
            if(hero == null)
            {
                return NotFound("Hero is not found");
            }
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            _db.SuperHeroes.Add(hero);
            _db.SaveChanges();

            return Ok(await _db.SuperHeroes.ToListAsync());

        }
        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero updatehero)
        {
            var dbHero = await _db.SuperHeroes.FindAsync(updatehero.Id);
            if(dbHero == null)
                return NotFound("Hero is not found");
            dbHero.Name = updatehero.Name;
            dbHero.FirstName = updatehero.FirstName;
            dbHero.LastName = updatehero.LastName;
            dbHero.Place = updatehero.Place;

            await _db.SaveChangesAsync();

            return Ok(await _db.SuperHeroes.ToListAsync());

        
        }

        [HttpDelete]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var dbHero = await _db.SuperHeroes.FindAsync(id);
            if (dbHero == null)
                return NotFound("Hero is not found");
            _db.SuperHeroes.Remove(dbHero);

            await _db.SaveChangesAsync();

            return Ok(await _db.SuperHeroes.ToListAsync());




        }

    }
}
