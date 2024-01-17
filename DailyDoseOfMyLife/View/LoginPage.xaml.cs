using DailyDoseOfMyLife.Model;
using System.Security.Cryptography.X509Certificates;

namespace DailyDoseOfMyLife.View;

public partial class LoginPage : ContentPage
{
	EventRepository eventRepository;
	public LoginPage()
	{
		eventRepository = new EventRepository();
		InitializeComponent();
	}

    private async void LogIn_Clicked(object sender, EventArgs e)
    {
		if(UserNameEntry.Text != null)
		{
		string userName = UserNameEntry.Text;
		eventRepository.SetUsername(userName);
		eventRepository.LoggedIn();
		Shell.Current.GoToAsync("HomePage");
		}
		else
		{
			await DisplayAlert("Error", $"Following fields can not be empty: Username?", "OK");

        }

    }
}