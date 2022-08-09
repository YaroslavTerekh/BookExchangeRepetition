using BookExchange.Databases.DbContexts;
using BookExchange.Databases.DbRepositories.Interfaces;
using BookExchange.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Databases.DbRepositories
{
    public class UsersRepository : IUsersRepository
    {
        private UsersDbContext _context { get; set; }
        public UsersRepository(UsersDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUser(int id)
        {
            return _context.Users.Where(u => u.ID == id).FirstOrDefault();
        }

        public void ModifyUserInfo(User user)
        {
            User originalUser = GetUser(user.ID);

            originalUser.Name = user.Name;
            originalUser.SecondName = user.SecondName;
            originalUser.Email = user.Email;
            originalUser.Address = user.Address;
            originalUser.Password = user.Password;
            originalUser.Role = user.Role;

            _context.SaveChanges();
        }
    }
}
