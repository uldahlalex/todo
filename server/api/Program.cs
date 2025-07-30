using efscaffold.Entities;
using Infrastructure.Postgres.Scaffolding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyDbContext>(conf =>
{
    conf.UseNpgsql();
});

var app = builder.Build();

app.MapGet("/", ([FromServices]MyDbContext dbContext) =>
{
    var myTodo = new Todo()
    {
        Description = "test",
        Title = "test title",
        Id = Guid.NewGuid().ToString(),
        Isdone = false,
        Priority = 5
    };
    dbContext.Todos.Add(myTodo);
    dbContext.SaveChanges();
    var objects = dbContext.Todos.ToList();
    return objects;
});

app.Run();
