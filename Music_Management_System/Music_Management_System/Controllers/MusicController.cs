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

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetMusicById([FromRoute] int id)
        {
           var music = await _db.music.FirstOrDefaultAsync(x => x.Id == id);
            if(music == null)
            {
                return NotFound();
            }
            return Ok(music);
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

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, Music musicupdated)
        {
            var music = await _db.music.FindAsync(id);
            if(music == null)
            {
                return NotFound();
            }
            music.SongName = musicupdated.SongName;
            music.SingerName = musicupdated.SingerName;
            music.ReleaseYear = musicupdated.ReleaseYear;
            music.MovieName = musicupdated.MovieName;
            music.SongType = musicupdated.SongType;

            await _db.SaveChangesAsync();
            return Ok(music);

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var music = await _db.music.FindAsync(id);
            if (music == null)
            {
                return NotFound();
            }
            _db.music.Remove(music);
            await _db.SaveChangesAsync();
            return Ok(music);
        }

    }
}
