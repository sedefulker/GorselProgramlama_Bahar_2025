using Microsoft.Maui;

namespace Odev2App;

public partial class VKIPage : ContentPage
{
	public VKIPage()
	{
		InitializeComponent();
		kiloSlider.Value = 70;
		boySlider.Value = 170;
		HesaplaVKI();
	}

	private void OnKiloBoyChanged(object sender, ValueChangedEventArgs e)
	{
		HesaplaVKI();
	}

	private void HesaplaVKI()
	{
		double kilo = kiloSlider.Value;
		double boyCm = boySlider.Value;
		double boyMetre = boyCm / 100;
		double vki = kilo / (boyMetre * boyMetre);

		kiloLabel.Text = $"{(int)kilo} kg";
		boyLabel.Text = $"{(int)boyCm} cm";
		vkiLabel.Text = $"VKÝ: {vki:F2}";
	}
}