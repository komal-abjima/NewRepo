using FirstAPIProject.Data;
using FirstAPIProject.Logging;
using FirstAPIProject.Models;
using FirstAPIProject.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace FirstAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]  
    public class VillaAPIController : ControllerBase
    {
        
        private readonly ApplicationDbContext _db;
        public VillaAPIController(ApplicationDbContext db)
        {
            
            _db = db;
            
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
       
        public ActionResult<IEnumerable<VillaDto>> GetVillas()
        {
     
            return Ok(_db.villas.ToList());
        }

        [HttpGet("{id:int}", Name = "GetVilla")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(200, Type = typeof(VillaDto)) //produces response type is used for remove undocumented 
        //public VillaDto GetVillaById(int id)
        public ActionResult<VillaDto> GetVillaById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            //var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            var villa = _db.villas.FirstOrDefault(u => u.Id == id);

            if (villa == null)
            {
                return NotFound();
            }
            return Ok(villa);

        }

        [HttpPost]

        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VillaDto> CreateVilla([FromBody]VillaDto villadto)
        {
            //if (VillaStore.villaList.FirstOrDefault(u => u.Name.ToLower() == villadto.Name.ToLower()) != null)
            if (_db.villas.FirstOrDefault(u => u.Name.ToLower() == villadto.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CustomError", "Villa already Exists");
                return BadRequest(ModelState);
            }
            if (villadto == null)
            {
                return BadRequest(villadto);
            }
            if (villadto.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            //villadto.Id = VillaStore.villaList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            //VillaStore.villaList.Add(villadto);
            Villa model = new()
            {
                Amenity = villadto.Amenity,
                Details = villadto.Details,
                Id = villadto.Id,
                ImageUrl = villadto.ImageUrl,
                Name = villadto.Name,
                Occupancy = villadto.Occupacy,
                Rate = villadto.Rate,
                Sqft = villadto.sqft
            };
            _db.villas.Add(model);
            _db.SaveChanges();

            //return Ok(villadto);
            return CreatedAtRoute("GetVilla", new { id = villadto.Id }, villadto);


        }

        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        [Produces("application/json")]
        public IActionResult DeleteVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            //var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            var villa = _db.villas.FirstOrDefault(u => u.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            //VillaStore.villaList.Remove(villa);
            _db.villas.Remove(villa);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [Produces("application/json")]
       
        public IActionResult UpdateVilla(int id, [FromBody] VillaDto villadto)
        {
            if (villadto == null || id != villadto.Id)
            {
                return BadRequest();

            }
            //var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            //villa.Name = villadto.Name;
            //villa.Occupacy = villadto.Occupacy;
            //villa.sqft = villadto.sqft;

            Villa model = new()
            {
                Id = villadto.Id,
                Name = villadto.Name,
                Details = villadto.Details,
                Occupancy = villadto.Occupacy,
                Sqft = villadto.sqft,
                Amenity = villadto.Amenity,
                ImageUrl = villadto.ImageUrl,
                Rate = villadto.Rate
            };

            _db.villas.Update(model);
            _db.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id:int}", Name = "UpdatePartial")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartial(int id, JsonPatchDocument<VillaDto> patchdto)
        {
            if (patchdto == null || id == 0)
            {
                return BadRequest();
            }
            //var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            var villa = _db.villas.AsNoTracking().FirstOrDefault(u => u.Id == id);
            VillaDto villaDto = new()
            {
                Amenity = villa.Amenity,
                Details = villa.Details,
                Id = villa.Id,
                Name = villa.Name,
                Occupacy = villa.Occupancy,
                ImageUrl = villa.ImageUrl,
                sqft = villa.Sqft
                    
            };
            
            if (villa == null)
            {
                return BadRequest();
            }
            // patchdto.ApplyTo(villa, ModelState);
            patchdto.ApplyTo(villaDto, ModelState);

            Villa model = new Villa()
            {
                Id = villaDto.Id,
                Name = villaDto.Name,
                Details = villaDto.Details,
                Occupancy = villaDto.Occupacy,
                Sqft = villaDto.sqft,
                Amenity = villaDto.Amenity,
                ImageUrl = villaDto.ImageUrl,
                Rate = villaDto.Rate
            };

            _db.villas.Update(model);
            _db.SaveChanges();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }



    }
}
