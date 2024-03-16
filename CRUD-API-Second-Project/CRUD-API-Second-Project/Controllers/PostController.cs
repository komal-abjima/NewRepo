using Azure.Core;
using CRUD_API_Second_Project.Data;
using CRUD_API_Second_Project.Models.DTO;
using CRUD_API_Second_Project.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_API_Second_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public PostController(ApplicationDbContext db )
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await _db.Posts.ToListAsync();
            return Ok(posts);
        }
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetPostById")]
        public async Task<IActionResult> GetPostById(Guid id)
        {
           var post = await _db.Posts.FirstOrDefaultAsync(x => x.Id == id);
           return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> AddPost(AddPostRequest request)
        {
            var post = new Post()
            {
                Title = request.Title,
                Content = request.Content,
                Summary = request.Summary,
                UrlHandle = request.UrlHandle,
                FeaturedImageUrl = request.FeaturedImageUrl,
                Visible = request.Visible,
                Author = request.Author,
                PublishDate = request.PublishDate,
                UpdateDate = request.UpdateDate

            };
            post.Id = Guid.NewGuid();
            await _db.Posts.AddAsync(post);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPostById), new {id = post.Id}, post);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdatePost([FromRoute]Guid id, UpdatePostRequest updatepost)
        {
            var existingpost = await _db.Posts.FindAsync(id);
            if ((existingpost != null))
            {
                existingpost.Title = updatepost.Title;
                existingpost.Content = updatepost.Content;
                existingpost.Author = updatepost.Author;
                existingpost.FeaturedImageUrl = updatepost.FeaturedImageUrl;
                existingpost.PublishDate = updatepost.PublishDate;
                existingpost.UpdateDate = updatepost.UpdateDate;
                existingpost.Summary = updatepost.Summary;
                existingpost.UrlHandle = updatepost.UrlHandle;
                existingpost.Visible =  updatepost.Visible;

                await _db.SaveChangesAsync();
                return Ok(existingpost);

            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeletePost(Guid id)
        {
            var existingDelete = await _db.Posts.FindAsync(id);
            if(existingDelete != null)
            {
                _db.Remove(existingDelete);
                await _db.SaveChangesAsync();
                return Ok(existingDelete);

            }
            return NotFound();
        }
    }
}
