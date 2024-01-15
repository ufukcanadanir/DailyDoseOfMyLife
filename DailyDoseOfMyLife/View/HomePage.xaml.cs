using DailyDoseOfMyLife.Model;
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
    }
    protected override async void OnAppearing()
    {
        Dictionary<string, string> weatherInfo = await weatherAPI.GetWeather();
        base.OnAppearing();
        var todos = new List<EventInfo>(await eventRepository.GetAllEvents());
        TodoList.ItemsSource = todos;
        Temperature.Text = weatherInfo["Temperature"].ToString()+ "°C";
        WeatherState.Text = weatherInfo["WeatherState"].ToString().ToUpper();

    }


    private async void AddButton_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(todoEntry.Text))
        {
            await DisplayAlert("Error", $"Following fields can not be empty: {todoEntry}?", "OK");
        }
        else
        {
            EventInfo todos = new EventInfo
            {
                Name = todoEntry.Text,
                Date = DateTime.Now,
                isChecked = false
            };


            await eventRepository.AddEvent(todos);
            LoadTodos();
        }
    }
    private async void LoadTodos()
    {
        var todos= new List<EventInfo>(await eventRepository.GetAllEvents());
        TodoList.ItemsSource = todos;
    }
}