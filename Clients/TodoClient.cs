using System;
using System.Text.Json;
using TodoFrontEnd.Models;

namespace TodoFrontEnd.Clients;

public class TodoClient(HttpClient httpClient)
{
    // public List<TodoItem> todos = [
    //     new TodoItem(){Id=1,Name = "Wash Dishes",DueDate=DateOnly.Parse("2025-1-11"), IsCompeleted=false},
    //     new TodoItem(){Id=2,Name = "Laundry",DueDate=DateOnly.Parse("2025-1-11"),IsCompeleted=false},
    //     new TodoItem(){Id=3,Name = "Buy Milk",DueDate=DateOnly.Parse("2025-1-11"),IsCompeleted=true}
    // ];

    // public List<TodoItem> GetTodoItems()
    // {
    //     return todos;
    // }

    // public void AddTodoItem(string name, DateOnly dueDate)
    // {

    //     todos.Add(new TodoItem(){
    //         Id = todos.Count+1,
    //         Name = name,
    //         DueDate = dueDate,
    //         IsCompeleted = false
    //     });
    // }

    // public void UpdateTodo(TodoItem updatedTodo)
    // {
    //     var todo = todos.Single(todo => todo.Id == updatedTodo.Id);
    //     todo.Name = updatedTodo.Name;
    //     todo.IsCompeleted = updatedTodo.IsCompeleted;
    //     todo.DueDate = updatedTodo.DueDate;
    //     // Console.WriteLine($"Updated: Id [{updatedTodo.Id}], Name [{updatedTodo.Name}], Is Completed [{updatedTodo.IsCompeleted.ToString()}]");
    // }

    public async Task<List<TodoItem>> GetAllItemsAsync()
        => await httpClient.GetFromJsonAsync<List<TodoItem>>("todos") ?? [];

    public async Task<List<TodoItem>> GetTodoItemsAsync()
        => await httpClient.GetFromJsonAsync<List<TodoItem>>("todos/undone") ?? [];
    
    public async Task<List<TodoItem>> GetDoneItemsAsync()
        => await httpClient.GetFromJsonAsync<List<TodoItem>>("todos/done") ?? [];

    public async Task AddTodoItemAsync(TodoItem todo)
        => await httpClient.PostAsJsonAsync("todos",todo);

    public async Task UpdateTodoAsync(TodoItem updatedTodo)
        => await httpClient.PutAsJsonAsync($"todos/{updatedTodo.Id}",updatedTodo);

    public async Task DeleteTodoAsync(int id)
        => await httpClient.DeleteAsync($"todos/{id}");
    
    public async Task TogglePinAsync(TodoItem updatedTodo)
    {
        updatedTodo.IsPinned = !updatedTodo.IsPinned;
        await httpClient.PutAsJsonAsync($"todos/{updatedTodo.Id}",updatedTodo);
    }
        
}
