namespace MauiPowerlifting.Pages;

public partial class MaxesPage : ContentPage
{
	public MaxesPage()
	{
		InitializeComponent();
	}

    void OnSquatChanged(object sender, TextChangedEventArgs e)
    {
        string oldText = e.OldTextValue;
        string newText = e.NewTextValue;
        string myText = Squat.Text;
    }
    void OnBenchChanged(object sender, TextChangedEventArgs e)
    {
        string oldText = e.OldTextValue;
        string newText = e.NewTextValue;
        string myText = Bench.Text;
    }
    void OnDeadliftChanged(object sender, TextChangedEventArgs e)
    {
        string oldText = e.OldTextValue;
        string newText = e.NewTextValue;
        string myText = Deadlift.Text;
    }
    void OnMilitaryPressChanged(object sender, TextChangedEventArgs e)
    {
        string oldText = e.OldTextValue;
        string newText = e.NewTextValue;
        string myText = MilitaryPress.Text;
    }
}