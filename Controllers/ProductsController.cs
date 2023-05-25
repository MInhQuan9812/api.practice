using bookstore.api.Models;
using bookstore.api.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bookstore.api.Controllers
{
    [Route("[controller]")]
    [Authorize]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IBookRepository _bookRepo;

        public ProductsController(IBookRepository repo)
        {
            _bookRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                return Ok(await _bookRepo.GetAllBookAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var book = await _bookRepo.GetBookByIdAsync(id);
            return book == null ? NotFound() : Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct(BookDto model)
        {
            var newBookId = await _bookRepo.AddBookAsync(model);
            return newBookId == null ? NotFound() : Ok(_bookRepo.GetBookByIdAsync(newBookId));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, BookDto model)
        {

            if (id != model.Id)
            {
                await _bookRepo.UpdateBookAsync(id, model);
                return Ok(_bookRepo.GetBookByIdAsync(id));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await _bookRepo.DeleteBookAsync(id);
                return Ok(); 
            }
            catch(Exception ex)
            {
                return NotFound();
            }
        }

    }
}
