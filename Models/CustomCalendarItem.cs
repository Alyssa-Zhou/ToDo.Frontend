using System;
using Heron.MudCalendar;

namespace TodoFrontEnd.Models;

public class CustomCalendarItem : CalendarItem
{
    public bool IsCompleted {get;set;} = false;
}
