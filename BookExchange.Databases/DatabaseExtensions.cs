using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BookExchange.Databases.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookExchange.Databases
{
    public static class DatabaseExtensions
    {
        public static IServiceCollection AddDbContextsCustom(this IServiceCollection services, IConfiguration builder)
        {
            services.AddDbContext<ContentDbContext>(
                o => o.UseSqlServer(builder.GetConnectionString("ContentConnection"), b => b.MigrationsAssembly("BookExchange")));
            services.AddDbContext<UsersDbContext>(
                o => o.UseSqlServer(builder.GetConnectionString("UsersConnection"), b => b.MigrationsAssembly("BookExchange")));
            return services;
        }
    }
}
