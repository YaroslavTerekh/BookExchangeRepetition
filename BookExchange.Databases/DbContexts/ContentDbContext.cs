using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookExchange.Domain.Models;

namespace BookExchange.Databases.DbContexts
{
    public class ContentDbContext : DbContext
    {
        public ContentDbContext(DbContextOptions<ContentDbContext> opts) : base(opts) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<ExchangeOrder> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<ExchangeOrder>()
                .HasOne(e => e.FirstBook)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ExchangeOrder>()
                .HasOne(e => e.SecondBook)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
