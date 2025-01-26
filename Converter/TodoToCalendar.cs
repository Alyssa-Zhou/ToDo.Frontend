using System;
using TodoFrontEnd.Models;

namespace TodoFrontEnd.Converter;

public static class TodoToCalendar
{
    public static List<CustomCalendarItem> ConvertToCalendar(List<TodoItem> todos)
    {
        return todos.Select(todo => new CustomCalendarItem
        {
            Start = todo.DueDate.ToDateTime(new TimeOnly(9, 0)), // 假设默认开始时间为 DueDate 的上午 9 点
            End = todo.DueDate.ToDateTime(new TimeOnly(10, 0)), // 假设默认结束时间为 DueDate 的上午 10 点
            Text = todo.Name,
            IsCompleted = todo.IsCompleted
        }).ToList();
    }
}
