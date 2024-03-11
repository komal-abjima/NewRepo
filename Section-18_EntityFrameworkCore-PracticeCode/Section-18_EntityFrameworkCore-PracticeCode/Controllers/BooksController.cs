using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
