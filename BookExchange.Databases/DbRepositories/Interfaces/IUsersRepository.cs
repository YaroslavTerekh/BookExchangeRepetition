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
        public Task<IEnumerable<User>> GetAllUsers();
        public Task<User> GetUser(int id);
        public Task ModifyUserInfo(User user);
    }
}
