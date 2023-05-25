using bookstore.api.Data;
using bookstore.api.Models;

namespace bookstore.api.Repositories
{
    public interface IBookRepository
    {
        public Task<List<BookDto>> GetAllBookAsync();
        public Task<BookDto> GetBookByIdAsync(int id);
        public Task<int> AddBookAsync(BookDto model);
        public Task UpdateBookAsync(int id,BookDto model);
        public Task DeleteBookAsync(int id);
    }
}
