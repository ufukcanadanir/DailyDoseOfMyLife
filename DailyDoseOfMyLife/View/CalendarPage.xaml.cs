namespace DailyDoseOfMyLife.View;

public partial class CalendarPage : ContentPage
{
	public CalendarPage()
	{
		InitializeComponent();
	}


    private void GoBack_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//HomePage");
        

    }
}