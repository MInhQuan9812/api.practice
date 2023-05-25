using AutoMapper;
using bookstore.api.Data;
using bookstore.api.Models;
using Microsoft.EntityFrameworkCore;

namespace bookstore.api.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public BookRepository(BookStoreContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddBookAsync(BookDto model)
        {
            var newBook = _mapper.Map<Book>(model);
            _context.Books!.Add(newBook);
            await _context.SaveChangesAsync();
            return newBook.Id;
        }

        public async Task DeleteBookAsync(int id)
        {
            var deletedBook = _context.Books!.SingleOrDefault(x => x.Id == id);
            if(deletedBook != null)
            {
                _context.Books!.Remove(deletedBook);
                await _context.SaveChangesAsync();
            }   
        }

        public async Task<List<BookDto>> GetAllBookAsync()
        {
            var books = await _context.Books!.ToListAsync();
            return _mapper.Map<List<BookDto>>(books);  
        }

        public async Task<BookDto> GetBookByIdAsync(int id)
        {
            var book = await _context.Books!.FindAsync(id);
            return _mapper.Map<BookDto>(book);
        }

        public async Task UpdateBookAsync(int id, BookDto model)
        {
            if (id == model.Id)
            {
                var updateBook = _mapper.Map<Book>(model);
                _context.Books!.Update(updateBook);
                await _context.SaveChangesAsync();
            }
        }
    }
}
