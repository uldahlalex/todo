using System.ComponentModel.DataAnnotations;

namespace api;

public class AppOptions
{
    [MinLength(1)]
    public string DbConnectionString { get; set; }
}