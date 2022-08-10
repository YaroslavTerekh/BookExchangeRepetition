using BookExchange.Databases.DbRepositories.Interfaces;
using BookExchange.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookExchange.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IContentRepository _contentRepo;

        public BooksController(IContentRepository contentRepo)
        {
            _contentRepo = contentRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> Books()
        {
            return await _contentRepo.GetAllBooks();
        }

        [HttpGet("{id}")]
        public async Task<Book> GetBook(int id)
        {
            return await _contentRepo.GetBook(id);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            await _contentRepo.AddBook(book);

            return CreatedAtAction(nameof(_contentRepo.AddBook), new { id = book.Id }, book);
        }

        [HttpPut]
        public async Task<IActionResult> ModifyBook(Book book)
        {
            await _contentRepo.ModifyBook(book);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _contentRepo.DeleteBook(id);

            return NoContent();
        }
    }
}
