namespace Odev2App;

public partial class KrediPage : ContentPage
{
	public KrediPage()
	{
		InitializeComponent();
	}

	private void OnVadeChanged(object sender, ValueChangedEventArgs e)
	{
		vadeLabel.Text = $"{(int)e.NewValue} Ay";
	}

	private void OnHesaplaClicked(object sender, EventArgs e)
	{
		if (double.TryParse(tutarEntry.Text, out double tutar) &&
			double.TryParse(faizEntry.Text, out double faiz))
		{
			int vade = (int)vadeSlider.Value;
			double aylikFaiz = faiz / 100 / 12;
			double taksit = tutar * aylikFaiz / (1 - Math.Pow(1 + aylikFaiz, -vade));
			double toplam = taksit * vade;
			sonucLabel.Text = $"Aylık Taksit: {taksit:F2} ₺\nToplam Ödeme: {toplam:F2} ₺";
		}
		else
		{
			DisplayAlert("Hata", "Lütfen geçerli bir tutar ve faiz oranı giriniz.", "Tamam");
		}
	}
}