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
    public class UserController : ControllerBase
    {
        private readonly IUsersRepository _usersRepo;
        private readonly IMapper _mapper;

        public UserController(IUsersRepository usersRepo, IMapper mapper)
        {
            _usersRepo = usersRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Users()
        {
            try{
                var users = await _usersRepo.GetAllUsers();

                return Ok(_mapper.Map<IEnumerable<UserDTO>>(users));
            }
            catch(Exception exc)
            {
                return StatusCode(500, exc.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            try
            {
                return Ok(_mapper.Map<UserDTO>(_usersRepo.GetUser(id)));
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
                return Ok(_usersRepo.ModifyUserInfo(user));
            }
            catch (Exception exc)
            {
                return StatusCode(500, exc.Message);
            }
        }
    }
}
