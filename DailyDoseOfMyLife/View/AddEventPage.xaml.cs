using DailyDoseOfMyLife.Model;
using Plugin.Maui.Calendar.Models;

namespace DailyDoseOfMyLife.View;

public partial class AddEventPage : ContentPage
{
    EventRepository eventRepository;
    public EventCollection Events { get; set; }
    DateTime todaysDate = DateTime.Now;
	public AddEventPage()
	{
        eventRepository = new EventRepository();
        Events = new EventCollection();
		InitializeComponent();
	}

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        string userName = eventRepository.GetUsername();
        EventInfo todos = new EventInfo
        {
            userName = userName,
            Name = NameEntry.Text,
            Date = DateTime.Today,
            isChecked = false
        };
        await eventRepository.AddEvent(todos);
        await Shell.Current.GoToAsync("..");
    }

    private void BackButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}