namespace GorselProgramlamaOdev2;

public partial class CreditPage : ContentPage
{
	public CreditPage()
	{
		InitializeComponent();

		// Kredi t�rlerini Picker'a ekle
		CreditTypePicker.Items.Add("�htiya� Kredisi");
		CreditTypePicker.Items.Add("Ta��t Kredisi");
		CreditTypePicker.Items.Add("Konut Kredisi");
	}

	// Vade s�resi de�i�tik�e g�ncellenir
	private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
	{
		DurationLabel.Text = $"Vade: {(int)e.NewValue} Ay";
	}

	// Kredi hesaplama i�lemi
	private async void OnCalculateClicked(object sender, EventArgs e)
	{
		try
		{
			// Kredi t�r� se�ilmemi�se uyar
			if (CreditTypePicker.SelectedIndex == -1)
			{
				await DisplayAlert("Hata", "L�tfen kredi t�r�n� se�in.", "Tamam");
				return;
			}

			// Giri� verilerini al
			double interestRate = double.Parse(InterestRateEntry.Text) / 100;
			double principalAmount = double.Parse(CreditAmountEntry.Text);
			int duration = (int)DurationSlider.Value;

			// Se�ilen kredi t�r�ne g�re KKDF ve BSMV oranlar�
			double kkdf = 0, bsmv = 0;
			switch (CreditTypePicker.SelectedItem.ToString())
			{
				case "�htiya� Kredisi":
					kkdf = 0.15;
					bsmv = 0.10;
					break;
				case "Ta��t Kredisi":
					kkdf = 0.15;
					bsmv = 0.05;
					break;
				case "Konut Kredisi":
					kkdf = 0.0;
					bsmv = 0.0;
					break;
			}

			// Ayl�k faiz oran�
			double monthlyRate = interestRate + (interestRate * kkdf) + (interestRate * bsmv);

			// Taksit hesaplama (e�it taksit y�ntemi - ann�ite)
			double installment = (Math.Pow(1 + monthlyRate, duration) * monthlyRate) /
								 (Math.Pow(1 + monthlyRate, duration) - 1) * principalAmount;

			// Toplam �deme ve faiz hesaplama
			double totalPayment = installment * duration;
			double totalInterest = totalPayment - principalAmount;

			// Sonu�lar� g�ster
			ResultLabel.Text = $"Ayl�k Taksit: {installment:F2} TL\n" +
							   $"Toplam �deme: {totalPayment:F2} TL\n" +
							   $"Toplam Faiz: {totalInterest:F2} TL";
		}
		catch (Exception)
		{
			await DisplayAlert("Hata", "L�tfen t�m alanlar� eksiksiz ve do�ru doldurun.", "Tamam");
		}
	}
}