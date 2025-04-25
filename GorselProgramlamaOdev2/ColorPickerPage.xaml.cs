namespace GorselProgramlamaOdev2;

public partial class ColorPickerPage : ContentPage
{
	public ColorPickerPage()
	{
		InitializeComponent();
		UpdateColor();
	}

	private void OnColorChanged(object sender, ValueChangedEventArgs e)
	{
		UpdateColor(); // Renk seçildiðinde sadece renk kodunu ve BoxView güncellenir
	}

	private void UpdateColor()
	{
		int red = (int)RedSlider.Value;
		int green = (int)GreenSlider.Value;
		int blue = (int)BlueSlider.Value;
		string hexColor = $"#{red:X2}{green:X2}{blue:X2}";

		// Slider etiketlerini güncelle
		RedLabel.Text = $"Kýrmýzý: {red}";
		GreenLabel.Text = $"Yeþil: {green}";
		BlueLabel.Text = $"Mavi: {blue}";

		// Renk kodunu ve BoxView'in rengini güncelle
		HexColorLabel.Text = hexColor;
		ColorDisplay.Color = Color.FromRgba(red / 255.0, green / 255.0, blue / 255.0, 1.0);
	}

	private async void OnCopyColorCode(object sender, EventArgs e)
	{
		// Renk kodunu panoya kopyala
		await Clipboard.SetTextAsync(HexColorLabel.Text);
		await DisplayAlert("Kopyalandý", $"Renk kodu: {HexColorLabel.Text}", "Tamam");

		// Sayfa arka planýný güncelle
		int red = (int)RedSlider.Value;
		int green = (int)GreenSlider.Value;
		int blue = (int)BlueSlider.Value;
		this.BackgroundColor = Color.FromRgba(red / 255.0, green / 255.0, blue / 255.0, 1.0);
	}

	private void OnRandomColor(object sender, EventArgs e)
	{
		Random random = new Random();
		RedSlider.Value = random.Next(0, 256);
		GreenSlider.Value = random.Next(0, 256);
		BlueSlider.Value = random.Next(0, 256);
		UpdateColor(); // Rastgele renk ayarlandýðýnda sadece BoxView ve Hex kodu güncellenir
	}
}