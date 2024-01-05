using Plugin.Maui.Calendar.Controls;
using Plugin.Maui.Calendar.Models;
namespace DailyDoseOfMyLife.View;

public partial class HomePage : ContentPage
{
	public EventCollection Events { get; set; }
	public HomePage()
	{
		Events = new EventCollection();
		InitializeComponent();
	}

    private void AddEventButton_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("AddEventPage");
    }
}