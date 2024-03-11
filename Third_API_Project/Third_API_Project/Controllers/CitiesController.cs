using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Third_API_Project.Data;
using Third_API_Project.Models;

namespace Third_API_Project.Controllers
{
  
    public class CitiesController : CustomControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Cities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetCities()
        {
            var cities = await _context.Cities.OrderBy(temp => temp.CityName).ToListAsync();
            return cities;
        }

        // GET: api/Cities/5
        [HttpGet("{CityID}")]
        public async Task<ActionResult<City>> GetCity(Guid CityID)
        {
            var city = await _context.Cities.FirstOrDefaultAsync(temp => temp.CityID == CityID);

            if (city == null)
            {
                //return NotFound();
                return Problem(detail: "Invalid CityID", statusCode: 400, title: "City Search");
            }

            return city;
        }

        
        [HttpPut("{CityID}")]
        public async Task<IActionResult> PutCity(Guid CityID, [Bind(nameof(City.CityID), 
            nameof(City.CityName))] City city)
        {
            if (CityID != city.CityID)
            {
                return BadRequest(); //http 400
            }

             var existingCity = await _context.Cities.FindAsync(CityID);
            if(existingCity == null)
            {
                return NotFound(); //http 404
            }
            existingCity.CityName = city.CityName;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(CityID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

       
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<City>> PostCity([Bind(nameof(City.CityID),
            nameof(City.CityName))]City city)
        {
            if(_context.Cities == null)
            {
                return Problem("Entity set is null");
            }
            _context.Cities.Add(city);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCity", new { CityID = city.CityID }, city);
        }

        // DELETE: api/Cities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(Guid id)
        {
            var city = await _context.Cities.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }

            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CityExists(Guid id)
        {
            return _context.Cities.Any(e => e.CityID == id);
        }
    }
}
