using Section_18_EntityFrameworkCore_PracticeCode.Models;

namespace Section_18_EntityFrameworkCore_PracticeCode.Repository
{
    public interface IBookRepository
    {
        Task<List<BookModel>> GetAll();
    }
}
