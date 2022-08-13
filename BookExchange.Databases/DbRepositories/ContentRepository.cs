using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookExchange.Databases.DbContexts;
using BookExchange.Domain.Models;
using System.Linq;
using BookExchange.Databases.DbRepositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _context.Books
                .Include(b => b.Image)
                .ToListAsync();
        }

        public async Task AddBook(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task<Book?> GetBook(Guid id)
        {
            return await _context.Books.Where(b => b.Id == id)
                .Include(b => b.Image)
                .FirstOrDefaultAsync();
        }

        public async Task DeleteBook(Guid id)
        {
            _context.Books.Remove(await GetBook(id));
            await _context.SaveChangesAsync();
        }

        public async Task ModifyBook(Book book)
        {
            Book originalBook = await GetBook(book.Id);

            originalBook.Title = book.Title;
            originalBook.Description = book.Description;
            originalBook.Image.Path = book.Image.Path;

            await _context.SaveChangesAsync();
        }
        //Orders
        public async Task<IEnumerable<ExchangeOrder>> GetAllOrders()
        {
            return await _context.Orders
                .ToListAsync();
        }

        public async Task AddOrder(ExchangeOrder order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task<ExchangeOrder?> GetOrder(Guid id)
        {
            return await _context.Orders.Where(o => o.Id == id)                
                .FirstOrDefaultAsync();
        }

        public async Task DeleteOrder(Guid id)
        {
            _context.Orders.Remove(await GetOrder(id));
            await _context.SaveChangesAsync();
        }

        public async Task ModifyOrder(ExchangeOrder order)
        {
            ExchangeOrder originalOrder = await GetOrder(order.Id);

            originalOrder.FirstBookId = order.FirstBookId;
            originalOrder.SecondBookId = order.SecondBookId;
            originalOrder.IsApproved = order.IsApproved;

            await _context.SaveChangesAsync();
        }
        // Users
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUser(Guid id)
        {
            return await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task RegisterUser(User user)
        {

        }

        public async Task ModifyUserInfo(User user)
        {
            _context.Update(user);

            await _context.SaveChangesAsync();
        }
    }
}
