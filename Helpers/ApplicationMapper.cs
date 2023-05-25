using AutoMapper;
using bookstore.api.Data;
using bookstore.api.Models;

namespace bookstore.api.Helpers
{
    public class ApplicationMapper :Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Book,BookDto>().ReverseMap();
        }
    }
}
