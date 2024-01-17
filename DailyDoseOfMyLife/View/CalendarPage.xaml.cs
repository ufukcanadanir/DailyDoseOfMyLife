using DailyDoseOfMyLife.Model;
using Plugin.Maui.Calendar.Models;
namespace DailyDoseOfMyLife.View;



public partial class CalendarPage : ContentPage
{   
    EventRepository eventRepository;
    EventCollection TodoList { get; set; }
	public CalendarPage()
	{
        eventRepository = new EventRepository();
        eventRepository.LoggingIn();
        TodoList = new EventCollection();
		InitializeComponent();
        //LoadEvents();
        TodoList = new EventCollection
        {
            [DateTime.Now] = new List<EventModel>
    {
        new EventModel { Name = "Cool event1"},
        new EventModel { Name = "Cool event2"}
    },
            // 5 days from today
            [DateTime.Now.AddDays(5)] = new List<EventModel>
    {
        new EventModel { Name = "Cool event3"},
        new EventModel { Name = "Cool event4"}
    },
            // 3 days ago
            [DateTime.Now.AddDays(-3)] = new List<EventModel>
    {
        new EventModel { Name = "Cool event5"}
    },
            // custom date
            [new DateTime(2024, 1, 18)] = new List<EventModel>
    {
        new EventModel { Name = "Cool event6"}
    }
        };
        BindingContext = this;
    }
    private async void LoadEvents()
    {
        var todos = new List<EventInfo>(await eventRepository.GetAllEvents());
        foreach (EventInfo e in todos)
        {
            DateTime eventDate = new DateTime(e.Date.Ticks);
            TodoList[eventDate] = new List<EventModel> { new EventModel { Name = e.Name } };
        }
        }

    private void AddEvent_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("AddEventPage");
    }
    internal class EventModel
    {
        public required string Name { get; set; }
    }
}