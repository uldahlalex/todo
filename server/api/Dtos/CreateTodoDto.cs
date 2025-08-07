using System.ComponentModel.DataAnnotations;

namespace api.Dtos;

public record CreateTodoDto(
    [Range(0,5)]
    int priority, string title, string description);