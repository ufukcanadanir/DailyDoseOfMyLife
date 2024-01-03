namespace DailyDoseOfMyLife.View;

public partial class ProfilePage : ContentPage
{
	public ProfilePage()
	{
		InitializeComponent();
	}

    private void GoBack_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//HomePage");
    }
}