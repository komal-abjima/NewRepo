using AutoMapper;
using Azure;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Section_18_EntityFrameworkCore_PracticeCode.Data;
using Section_18_EntityFrameworkCore_PracticeCode.Helpers;
using Section_18_EntityFrameworkCore_PracticeCode.Models;


namespace Section_18_EntityFrameworkCore_PracticeCode.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public BookRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<List<BookModel>> GetAll()
        {
            //var records = await _db.Books.Select(x => new BookModel()
            //{
            //    Id = x.Id,
            //    Title = x.Title,
            //    Description = x.Description,

            //}).ToListAsync();

            //return records;
            var records = await _db.Books.ToListAsync();
            return _mapper.Map<List<BookModel>>(records);

        }

        public async Task<BookModel> GetBookbyId(int bookId)
        {
            //var records = await _db.Books.Where(x=> x.Id == bookId).Select(x => new BookModel()
            //{
            //    Id = x.Id,
            //    Title = x.Title,
            //    Description= x.Description,
            //}).FirstOrDefaultAsync();

            //return records;
            var book = await _db.Books.FindAsync(bookId);
            return _mapper.Map<BookModel>(book);
        }

        public async Task<int> AddBook([FromBody]BookModel bookmodel)
        {
            var book = new Books()
            {
                Title = bookmodel.Title,
                Description = bookmodel.Description,
            };

            _db.Books.Add(book);
            await _db.SaveChangesAsync();

            return book.Id;
            

        }

        public async Task UpdateBook(int bookId, BookModel bookmodel)
        {
            var book = await _db.Books.FindAsync(bookId);
            if (book != null)
            {
                book.Title = bookmodel.Title;
                book.Description = bookmodel.Description;

                await _db.SaveChangesAsync();
            }

            //it hit the data only one item
            //var book = new Books()
            //{
            //    Id = bookId,
            //    Title = bookmodel.Title,
            //    Description = bookmodel.Description,
            //};
            //_db.Books.Update(book);
            //await _db.SaveChangesAsync();

        }

        public async Task UpdateBookPatchAsync(int Id,JsonPatchDocument<Books> bookModel)
        {
            var book = await _db.Books.FindAsync(Id);
            if (book != null)
            {
                bookModel.ApplyTo(book);
                await _db.SaveChangesAsync();
            }
        }

        public async Task DeleteBook(int id)
        {
            //var book = _db.Books.Where(x => x.Title == "").FirstOrDefault();
            var book = new Books() { Id = id };
            _db.Books.Remove(book);

            await _db.SaveChangesAsync();
            //return book.Id;
        }



    }
}
