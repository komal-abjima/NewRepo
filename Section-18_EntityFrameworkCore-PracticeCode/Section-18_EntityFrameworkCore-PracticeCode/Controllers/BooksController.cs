using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Section_18_EntityFrameworkCore_PracticeCode.Data;
using Section_18_EntityFrameworkCore_PracticeCode.Models;
using Section_18_EntityFrameworkCore_PracticeCode.Repository;

namespace Section_18_EntityFrameworkCore_PracticeCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookrepo;
        public BooksController(IBookRepository bookrepo)
        {
            _bookrepo = bookrepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookrepo.GetAll();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var book = await _bookrepo.GetBookbyId(id);
            return Ok(book);
        }

        [HttpPost]
        //public async Task<ActionResult> AddBook(BookModel bookmodel)
        //{
        //    var addbook = await _bookrepo.AddBook(bookmodel);
        //    return Ok(addbook);
        //}
        public async Task<IActionResult> AddNewBook(BookModel bookmodel)
        {
            var id = await _bookrepo.AddBook(bookmodel);
            return CreatedAtAction(nameof(GetById), new { id = id, controller = "books" }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromBody] BookModel bookmodel, [FromRoute] int id)
        {
            await _bookrepo.UpdateBook(id, bookmodel);
            return Ok();

        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateBookPatch([FromBody] JsonPatchDocument<Books> bookModel, [FromRoute] int id)
        {
            await _bookrepo.UpdateBookPatchAsync(id, bookModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            await _bookrepo.DeleteBook(id);
            return Ok();
        }


        //resolve the service dependency directly in the action method
        //[HttpGet("name")]
        //public IActionResult GetName([FromServices] IBookRepository bookrepo)
        //{
        //    var name = _bookrepo.getname();
        //    return Ok(name);
        //}



    }
}
