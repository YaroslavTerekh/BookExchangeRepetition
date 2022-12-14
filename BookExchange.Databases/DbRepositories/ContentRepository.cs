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
                .Include(b => b.User)
                .ThenInclude(o => o.Address)
                .ToListAsync();
        }

        public async Task AddBook(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task<Book?> GetBook(int id)
        {
            return await _context.Books.Where(b => b.Id == id)
                .Include(b => b.Image)
                .Include(b => b.User)
                .ThenInclude(o => o.Address)
                .FirstOrDefaultAsync();
        }

        public async Task DeleteBook(int id)
        {
            _context.Books.Remove(await GetBook(id));
            await _context.SaveChangesAsync();
        }

        public async Task ModifyBook(Book book)
        {
            Book originalBook = await GetBook(book.Id);

            originalBook.Title = book.Title;
            originalBook.Description = book.Description;
            originalBook.Image = book.Image;

            await _context.SaveChangesAsync();
        }
        //Orders
        public async Task<IEnumerable<ExchangeOrder>> GetAllOrders()
        {
            return await _context.Orders
                .Include(o => o.FirstBook).ThenInclude(b => b.Image)
                .Include(o => o.FirstBook).ThenInclude(b => b.User.Address)
                .Include(o => o.SecondBook).ThenInclude(b => b.Image)
                .Include(o => o.SecondBook).ThenInclude(b => b.User.Address)
                .ToListAsync();
        }

        public async Task AddOrder(ExchangeOrder order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task<ExchangeOrder?> GetOrder(int id)
        {
            return await _context.Orders
                .Where(o => o.Id == id)
                .Include(o => o.FirstBook).ThenInclude(b => b.Image)
                .Include(o => o.FirstBook).ThenInclude(b => b.User.Address)
                .Include(o => o.SecondBook).ThenInclude(b => b.Image)
                .Include(o => o.SecondBook).ThenInclude(b => b.User.Address).FirstOrDefaultAsync();
        }

        public async Task DeleteOrder(int id)
        {
            _context.Orders.Remove(await GetOrder(id));
            await _context.SaveChangesAsync();
        }

        public async Task ModifyOrder(ExchangeOrder order)
        {
            ExchangeOrder originalOrder = await GetOrder(order.Id);

            originalOrder.FirstBook = order.FirstBook;
            originalOrder.SecondBook = order.SecondBook;

            await _context.SaveChangesAsync();
        }
        
        //Users
        public async Task<User> GetUser(int id)
        {
            return await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
        }
    }
}
