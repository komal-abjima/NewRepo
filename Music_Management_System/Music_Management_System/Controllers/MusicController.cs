using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Music_Management_System.Data;
using Music_Management_System.Models;

namespace Music_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public MusicController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<Music>> GetAll()
        {
            var musiclist = await _db.music.ToListAsync();
            return Ok(musiclist);
        }

        [HttpPost]
        public async Task<ActionResult<Music>> AddUser([FromBody] Music musicModel)
        {
            if (musicModel == null)
            {
                return BadRequest();
            }
            else
            {
                _db.music.Add(musicModel);
                await _db.SaveChangesAsync();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Music Added successfully!"
                });
            }

        }
    }
}
