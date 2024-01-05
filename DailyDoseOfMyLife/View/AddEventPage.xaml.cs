using DailyDoseOfMyLife.Model;

namespace DailyDoseOfMyLife.View;

public partial class AddEventPage : ContentPage
{
	public AddEventPage()
	{
		InitializeComponent();
	}

    private void SaveButton_Clicked(object sender, EventArgs e)
    {

    }

    private void BackButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}