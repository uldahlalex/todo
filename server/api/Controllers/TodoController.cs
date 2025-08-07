using efscaffold.Entities;
using Infrastructure.Postgres.Scaffolding;
using Microsoft.AspNetCore.Mvc;

[ApiController]
public class TodoController(MyDbContext dbContext) : ControllerBase
{
    [Route(nameof(GetAllTodos))]
    [HttpGet]
    public async Task<ActionResult<List<Todo>>> GetAllTodos()
    {
        var objects = dbContext.Todos.ToList();
        return objects;
    }

    [Route(nameof(CreateTodo))]
    [HttpPost]
    public async Task<ActionResult<Todo>> CreateTodo([FromBody]CreateTodoDto dto)
    {
        var myTodo = new Todo()
        {
            Description = dto.description,
            Title = dto.title,
            Id = Guid.NewGuid().ToString(),
            Isdone = false,
            Priority = dto.priority
        };
        dbContext.Todos.Add(myTodo);
        dbContext.SaveChanges();
        return myTodo;
    }
    
    
}