using api.Dtos;
using efscaffold;
using efscaffold.Entities;

namespace api.Services;

public class TodoService(MyDbContext dbContext) : ITodoService
{
    public async Task<Todo> CreateTodo(CreateTodoDto dto)
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

    public async Task<List<Todo>> GetAllTodos()
    {
        return dbContext.Todos.ToList();
    }
}