using Microsoft.Maui.ApplicationModel;

namespace Odev2App;

public partial class RenkPage : ContentPage
{
	public RenkPage()
	{
		InitializeComponent();
		OnColorChanged(null, null);
	}

	private void OnColorChanged(object sender, ValueChangedEventArgs e)
	{
		int r = (int)redSlider.Value;
		int g = (int)greenSlider.Value;
		int b = (int)blueSlider.Value;

		redLabel.Text = $"R: {r}";
		greenLabel.Text = $"G: {g}";
		blueLabel.Text = $"B: {b}";

		string hex = $"#{r:X2}{g:X2}{b:X2}";
		colorCodeLabel.Text = hex;
		anaLayout.BackgroundColor = Color.FromRgb(r, g, b);
	}

	private async void OnCopyClicked(object sender, EventArgs e)
	{
		await Clipboard.SetTextAsync(colorCodeLabel.Text);
		await DisplayAlert("Kopyalandý", colorCodeLabel.Text, "OK");
	}

	private void OnRandomClicked(object sender, EventArgs e)
	{
		Random rnd = new();
		redSlider.Value = rnd.Next(256);
		greenSlider.Value = rnd.Next(256);
		blueSlider.Value = rnd.Next(256);
	}
}