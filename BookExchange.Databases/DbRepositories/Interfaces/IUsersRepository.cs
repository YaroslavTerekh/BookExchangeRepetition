using BookExchange.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Databases.DbRepositories.Interfaces
{
    public interface IUsersRepository
    {
        public IEnumerable<User> GetAllUsers();
        public User GetUser(int id);
        public void ModifyUserInfo(User user);
    }
}
