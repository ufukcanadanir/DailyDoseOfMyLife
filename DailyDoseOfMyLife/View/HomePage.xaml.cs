using DailyDoseOfMyLife.Model;
using Microsoft.Maui.Controls;
using static DailyDoseOfMyLife.View.HomePage;
namespace DailyDoseOfMyLife.View;


public partial class HomePage : ContentPage
{
    EventRepository eventRepository;
    WeatherAPI weatherAPI;
    public HomePage()
    {
        InitializeComponent();
        eventRepository = new EventRepository();
        weatherAPI = new WeatherAPI();
        eventRepository.LoggingIn();
    }

   
    protected override async void OnAppearing()
    {
        Dictionary<string, string> weatherInfo = await weatherAPI.GetWeather();
        base.OnAppearing();
        var todos = new List<EventInfo>(await eventRepository.TodaysTodos());
        TodoList.ItemsSource = todos;
        Temperature.Text = weatherInfo["Temperature"].ToString() + "°C";
        WeatherState.Text = weatherInfo["WeatherState"].ToString().ToUpper();

    }


    private async void AddButton_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(todoEntry.Text))
        {
            await DisplayAlert("Error", $"Following fields can not be empty: {todoEntry.GetType}?", "OK");
        }
        else
        {
            string userName = eventRepository.GetUsername();
            EventInfo todos = new EventInfo
            {
                userName = userName,
                Name = todoEntry.Text,
                Date = DateTime.Today,
                isChecked = false
            };


            await eventRepository.AddEvent(todos);
            todoEntry.Text = "";
            LoadTodos();
        }
    }
    private async void LoadTodos()
    {
        var todos = new List<EventInfo>(await eventRepository.TodaysTodos());
        TodoList.ItemsSource = todos;
    }

    private async void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (sender is Microsoft.Maui.Controls.CheckBox checkBox && checkBox.BindingContext is EventInfo todo)
        {
            await eventRepository.ChangeIsChecked(todo);
        }
        LoadTodos();
    }
}