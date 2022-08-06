using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookExchange.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BookExchange.Databases.DbContexts
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions opts) : base(opts) { }

        public DbSet<User> Users { get; set; }
    }
}
