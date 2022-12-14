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
    public class OrdersController : ControllerBase
    {
        private readonly IContentRepository _contentRepo;
        private readonly IMapper _mapper;

        public OrdersController(IContentRepository contentRepo, IMapper mapper)
        {
            _contentRepo = contentRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Orders()
        {
            try
            {
                var orders = await _contentRepo.GetAllOrders();

                return Ok(_mapper.Map<IEnumerable<ExchangeOrderDTO>>(orders));
            }
            catch (Exception exc)
            {
                return StatusCode(500, exc.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            try
            {
                return Ok(_mapper.Map<ExchangeOrderDTO>(await _contentRepo.GetOrder(id)));
            }
            catch (Exception exc)
            {
                return StatusCode(500, exc.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(ExchangeOrderDTO order)
        {
            try
            {
                var newOrder = _mapper.Map<ExchangeOrder>(order);

                newOrder.FirstBook = await _contentRepo.GetBook(order.FirstBookId);
                newOrder.SecondBook = await _contentRepo.GetBook(order.SecondBookId);

                await _contentRepo.AddOrder(newOrder);

                return CreatedAtAction(nameof(_contentRepo.AddOrder), new { id = newOrder.Id }, newOrder);
            }
            catch (Exception exc)
            {
                return StatusCode(500, exc.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> ModifyOrder(ExchangeOrder order)
        {
            try
            {
                await _contentRepo.ModifyOrder(order);

                return Ok();
            }
            catch (Exception exc)
            {
                return StatusCode(500, exc.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            try
            {
                await _contentRepo.DeleteOrder(id);

                return Ok($"Orded with id {id} was deleted");
            }
            catch (Exception exc)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
