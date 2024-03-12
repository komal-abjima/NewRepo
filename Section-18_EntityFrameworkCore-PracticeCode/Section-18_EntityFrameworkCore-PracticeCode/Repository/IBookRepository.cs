
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

using Section_18_EntityFrameworkCore_PracticeCode.Models;
using Section_18_EntityFrameworkCore_PracticeCode.Data;

namespace Section_18_EntityFrameworkCore_PracticeCode.Repository
{
    public interface IBookRepository
    {
        Task<List<BookModel>> GetAll();
        Task<BookModel> GetBookbyId(int bookId);
        Task<int> AddBook(BookModel bookmodel);
        Task UpdateBook(int bookId, BookModel bookmodel);
        Task UpdateBookPatchAsync(int bookId, JsonPatchDocument<Books> bookModel);
        Task DeleteBook(int id);
    }
}
