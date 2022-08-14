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

                return Ok(/*_mapper.Map<IEnumerable<ExchangeOrderDTO>>(*/orders/*)*/);
            }
            catch (Exception exc)
            {
                return StatusCode(500, exc.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(Guid id)
        {
            try
            {
                return Ok(/*_mapper.Map<ExchangeOrderDTO>(*/await _contentRepo.GetOrder(id)/*)*/);
            }
            catch (Exception exc)
            {
                return StatusCode(500, exc.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(ExchangeOrder order)
        {
            try
            { 

                await _contentRepo.AddOrder(order);

                //return Ok(order);
                return CreatedAtAction(nameof(_contentRepo.AddOrder), new { id = order.Id }, order);
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
        public async Task<IActionResult> DeleteOrder(Guid id)
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