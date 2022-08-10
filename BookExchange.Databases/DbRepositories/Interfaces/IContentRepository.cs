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
        public Task<Book> GetBook(int id);
        public Task DeleteBook(int id);
        public Task ModifyBook(Book book);
        public IEnumerable<ExchangeOrder> GetAllOrders();     
        public Task AddOrder(ExchangeOrder order);
        public Task<ExchangeOrder> GetOrder(int id);
        public Task DeleteOrder(int id);
        public Task ModifyOrder(ExchangeOrder order);
    }
}
