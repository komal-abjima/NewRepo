using AutoMapper;
using Section_18_EntityFrameworkCore_PracticeCode.Data;
using Section_18_EntityFrameworkCore_PracticeCode.Models;

namespace Section_18_EntityFrameworkCore_PracticeCode.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Books, BookModel>().ReverseMap();
        }
    }
}
