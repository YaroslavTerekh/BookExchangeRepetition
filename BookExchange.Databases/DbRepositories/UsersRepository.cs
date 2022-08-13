//using BookExchange.Databases.DbContexts;
//using BookExchange.Databases.DbRepositories.Interfaces;
//using BookExchange.Domain.Models;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BookExchange.Databases.DbRepositories
//{
//    public class UsersRepository : IUsersRepository
//    {
//        private UsersDbContext _context { get; set; }
//        public UsersRepository(UsersDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<IEnumerable<User>> GetAllUsers()
//        {
//            return await _context.Users.ToListAsync();
//        }

//        public async Task<User> GetUser(int id)
//        {
//            return await _context.Users.Where(u => u.ID == id).FirstOrDefaultAsync();
//        }

//        public async Task ModifyUserInfo(User user)
//        {
//            User originalUser = await GetUser(user.ID);

//            originalUser.Name = user.Name;
//            originalUser.SecondName = user.SecondName;
//            originalUser.Email = user.Email;
//            originalUser.Address = user.Address;
//            originalUser.Password = user.Password;
//            originalUser.Role = user.Role;

//            await _context.SaveChangesAsync();
//        }
//    }
//}
