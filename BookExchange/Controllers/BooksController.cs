using AutoMapper;
using BookExchange.Databases.DbRepositories.Interfaces;
using BookExchange.Domain.Models;
using BookExchange.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookExchange.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IContentRepository _contentRepo;
        private readonly IMapper _mapper;

        public BooksController(IContentRepository contentRepo, IMapper mapper)
        {
            _mapper = mapper;
            _contentRepo = contentRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Books()
        {
            try
            {
                var books = await _contentRepo.GetAllBooks();
                
                return Ok(/*_mapper.Map<IEnumerable<BookDTO>>(*/books/*)*/);
            }
            catch (Exception exc)
            {
                return StatusCode(500, exc.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(Guid id)
        {
            try
            {
                return Ok(/*_mapper.Map<BookDTO>(*/await _contentRepo.GetBook(id)/*)*/);
            }
            catch(Exception exc)
            {
                return StatusCode(500, exc.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            try
            {
                await _contentRepo.AddBook(book);

                return CreatedAtAction(nameof(_contentRepo.AddBook), new { id = book.Id }, book);
            }
            catch(Exception exc)
            {
                return StatusCode(500, exc.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> ModifyBook(Book book)
        {
            try
            {
                await _contentRepo.ModifyBook(book);

                return Ok();
            }
            catch(Exception exc)
            {
                return StatusCode(500, exc.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            try
            {
                await _contentRepo.DeleteBook(id);

                return Ok($"Book with id {id} was deleted");
            }
            catch (Exception exc)
            {
                return StatusCode(500, exc.Message);
            }            
        }
    }
}
