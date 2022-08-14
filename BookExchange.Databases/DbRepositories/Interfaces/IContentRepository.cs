using BookExchange.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Databases.DbRepositories.Interfaces
{
    public interface IContentRepository
    {
        public Task<IEnumerable<Book>> GetAllBooks();
        public Task AddBook(Book book);
        public Task<Book> GetBook(Guid id);
        public Task DeleteBook(Guid id);
        public Task ModifyBook(Book book);
        public Task<IEnumerable<ExchangeOrder>> GetAllOrders();     
        public Task AddOrder(ExchangeOrder order);
        public Task<ExchangeOrder> GetOrder(Guid id);
        public Task DeleteOrder(Guid id);
        public Task ModifyOrder(ExchangeOrder order);
        public Task<IEnumerable<User>> GetAllUsers();
        public Task<User> GetUser(Guid id);
        public Task ModifyUserInfo(User user);
    }
}
