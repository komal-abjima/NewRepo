using Microsoft.EntityFrameworkCore;
using Section_18_EntityFrameworkCore_PracticeCode.Data;
using Section_18_EntityFrameworkCore_PracticeCode.Models;

namespace Section_18_EntityFrameworkCore_PracticeCode.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _db;

        public BookRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<BookModel>> GetAll()
        {
            var records = await _db.Books.Select(x => new BookModel()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,

            }).ToListAsync();

            return records;

        }
    }
}
