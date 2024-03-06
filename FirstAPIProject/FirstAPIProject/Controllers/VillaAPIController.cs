using FirstAPIProject.Data;
using FirstAPIProject.Logging;
using FirstAPIProject.Models;
using FirstAPIProject.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FirstAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]  //without this the validation is not working
    public class VillaAPIController : ControllerBase
    {
        //private readonly ILogger<VillaAPIController> _logger;

        //custom logger
        //private readonly ILogging _logger;

        //public VillaAPIController(Logger<VillaAPIController> logger)
        //public VillaAPIController(ILogging logger)
        private readonly ApplicationDbContext _db;
        public VillaAPIController(ApplicationDbContext db)
        {
            //_logger = logger;
            _db = db;
            
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //public IEnumerable<VillaDto> GetVillas()
        public ActionResult<IEnumerable<VillaDto>> GetVillas()
        {
            //_logger.Log("Getting all villas","");
            //return VillaStore.villaList;
            //return Ok(VillaStore.villaList);
            return Ok(_db.villas.ToList());
        }

        [HttpGet("{id:int}", Name = "GetVilla")]
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
            var villa = _db.villas.FirstOrDefault(x => x.Id == id);

            if (villa == null)
            {
                return NotFound();
            }
            return Ok(villa);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VillaDto> CreateVilla([FromBody] VillaDto villadto)
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
            var villa = _db.villas.FirstOrDefault(u => u.Id == id);
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
          
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }



    }
}
