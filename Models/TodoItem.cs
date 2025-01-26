using System;
using System.Text.Json.Serialization;

namespace TodoFrontEnd.Models;

public class TodoItem
{
    public int Id {get;set;}

    public string Name {get;set;} = string.Empty;

    public DateOnly DueDate {get;set;} = DateOnly.FromDateTime(DateTime.UtcNow);

    public bool IsCompleted {get;set;} = false;

    public bool IsPinned {get;set;} = false;
}
