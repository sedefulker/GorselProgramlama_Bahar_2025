namespace Odev2App;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnKrediPage(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new KrediPage());
	}

	private async void OnVKIPage(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new VKIPage());
	}

	private async void OnRenkPage(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new RenkPage());
	}
}