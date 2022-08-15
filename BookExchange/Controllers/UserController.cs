using AutoMapper;
using BookExchange.Databases.DbRepositories.Interfaces;
using BookExchange.Domain.Models;
using BookExchange.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookExchange.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IContentRepository _contentRepo;
        private readonly IMapper _mapper;

        public UserController(IContentRepository usersRepo, IMapper mapper)
        {
            _contentRepo = usersRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Users()
        {
            try{
                var users = await _contentRepo.GetAllUsers();

                return Ok(_mapper.Map<IEnumerable<UserDTO>>(users));
            }
            catch(Exception exc)
            {
                return StatusCode(500, exc.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            try
            {
                return Ok(_mapper.Map<UserDTO>(_contentRepo.GetUser(id)));
            }
            catch (Exception exc)
            {
                return StatusCode(500, exc.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> ModifyUser(User user)
        {
            try
            {
                return Ok(_contentRepo.ModifyUserInfo(user));
            }
            catch (Exception exc)
            {
                return StatusCode(500, exc.Message);
            }
        }
    }
}
