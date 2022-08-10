using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookExchange.Databases.DbContexts;
using BookExchange.Domain.Models;
using System.Linq;
using BookExchange.Databases.DbRepositories.Interfaces;

namespace BookExchange.Databases.DbRepositories
{
    public class ContentRepository : IContentRepository
    {
        private ContentDbContext _context { get; set; }
        public ContentRepository (ContentDbContext ctx)
        {
            _context = ctx;
        }
        //Books
        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public Book GetBook (int id)
        {
            return _context.Books.Where(b => b.Id == id).FirstOrDefault();
        }

        public void DeleteBook(int id)
        {
            _context.Books.Remove(GetBook(id));
            _context.SaveChanges();
        }

        public void ModifyBook(Book book)
        {
            Book originalBook = GetBook(book.Id);

            originalBook.Title = book.Title;
            originalBook.Description = book.Description;
            originalBook.Image = book.Image;

            _context.SaveChanges();
        }
        //Orders
        public IEnumerable<ExchangeOrder> GetAllOrders()
        {
            return _context.Orders.ToList();
        }

        public void AddOrder(ExchangeOrder order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public ExchangeOrder GetOrder(int id)
        {
            return _context.Orders.Where(o => o.Id == id).FirstOrDefault();
        }

        public void DeleteOrder(int id)
        {
            _context.Orders.Remove(GetOrder(id));
            _context.SaveChanges();
        }

        public void ModifyOrder(ExchangeOrder order)
        {
            var originalOrder = GetOrder(order.Id);

            originalOrder.FirstAddress = order.FirstAddress;
            originalOrder.SecondAddress = order.SecondAddress;
            originalOrder.FirstBookId = order.FirstBookId;
            originalOrder.SecondBookId = order.SecondBookId;

            _context.SaveChanges();
        }
    }
}
