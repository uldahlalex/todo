using api.Dtos;
using api.Services;
using efscaffold.Entities;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
public class TodoController(ITodoService todoService) : ControllerBase
{
    [Route(nameof(GetAllTodos))]
    [HttpGet]
    public async Task<ActionResult<List<Todo>>> GetAllTodos()
    {
        var todos = await todoService.GetAllTodos();
        return todos;
    }

    [Route(nameof(CreateTodo))]
    [HttpPost]
    public async Task<ActionResult<Todo>> CreateTodo([FromBody]CreateTodoDto dto)
    {
        var result = await todoService.CreateTodo(dto);
        return result;
    }

    [Route(nameof(ToggleDone))]
    [HttpPut]
    public async Task<ActionResult<Todo>> ToggleDone([FromBody]Todo t)
    {
        var result = await todoService.ToggleTodo(t);
        return result;
    }
    
    
}