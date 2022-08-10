using BookExchange.Databases;
using BookExchange.Databases.DbContexts;
using BookExchange.Databases.DbRepositories;
using BookExchange.Databases.DbRepositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Add SQL Server
builder.Services.AddDbContextsCustom(builder.Configuration);
//Depency Injection
builder.Services.AddTransient<IContentRepository, ContentRepository>();
builder.Services.AddTransient<IUsersRepository, UsersRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
