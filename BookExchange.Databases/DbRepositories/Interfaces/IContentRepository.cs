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
        public IEnumerable<Book> GetAllBooks();
        public void AddBook(Book book);
        public Book GetBook(int id);
        public void DeleteBook(int id);
        public void ModifyBook(Book book);
        public IEnumerable<ExchangeOrder> GetAllOrders();     
        public void AddOrder(ExchangeOrder order);
        public ExchangeOrder GetOrder(int id);
        public void DeleteOrder(int id);
        public void ModifyOrder(ExchangeOrder order);
    }
}
