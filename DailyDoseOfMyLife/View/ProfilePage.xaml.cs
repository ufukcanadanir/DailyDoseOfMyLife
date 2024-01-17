using DailyDoseOfMyLife.Model;

namespace DailyDoseOfMyLife.View;

public partial class ProfilePage : ContentPage
{
    EventRepository eventRepository;
	public ProfilePage()
	{
        eventRepository = new EventRepository();
        eventRepository.LoggingIn();
		InitializeComponent();
        
    }

    private void GoBack_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//HomePage");
    }

    private void LogOut_Clicked(object sender, EventArgs e)
    {
        eventRepository.LogOut();
        Shell.Current.GoToAsync(nameof(LoginPage)   );
    }
}