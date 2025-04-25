namespace GorselProgramlamaOdev2;

public partial class CreditPage : ContentPage
{
	public CreditPage()
	{
		InitializeComponent();

		// Kredi türlerini Picker'a ekle
		CreditTypePicker.Items.Add("Ýhtiyaç Kredisi");
		CreditTypePicker.Items.Add("Taþýt Kredisi");
		CreditTypePicker.Items.Add("Konut Kredisi");
	}

	// Vade süresi deðiþtikçe güncellenir
	private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
	{
		DurationLabel.Text = $"Vade: {(int)e.NewValue} Ay";
	}

	// Kredi hesaplama iþlemi
	private async void OnCalculateClicked(object sender, EventArgs e)
	{
		try
		{
			// Kredi türü seçilmemiþse uyar
			if (CreditTypePicker.SelectedIndex == -1)
			{
				await DisplayAlert("Hata", "Lütfen kredi türünü seçin.", "Tamam");
				return;
			}

			// Giriþ verilerini al
			double interestRate = double.Parse(InterestRateEntry.Text) / 100;
			double principalAmount = double.Parse(CreditAmountEntry.Text);
			int duration = (int)DurationSlider.Value;

			// Seçilen kredi türüne göre KKDF ve BSMV oranlarý
			double kkdf = 0, bsmv = 0;
			switch (CreditTypePicker.SelectedItem.ToString())
			{
				case "Ýhtiyaç Kredisi":
					kkdf = 0.15;
					bsmv = 0.10;
					break;
				case "Taþýt Kredisi":
					kkdf = 0.15;
					bsmv = 0.05;
					break;
				case "Konut Kredisi":
					kkdf = 0.0;
					bsmv = 0.0;
					break;
			}

			// Aylýk faiz oraný
			double monthlyRate = interestRate + (interestRate * kkdf) + (interestRate * bsmv);

			// Taksit hesaplama (eþit taksit yöntemi - annüite)
			double installment = (Math.Pow(1 + monthlyRate, duration) * monthlyRate) /
								 (Math.Pow(1 + monthlyRate, duration) - 1) * principalAmount;

			// Toplam ödeme ve faiz hesaplama
			double totalPayment = installment * duration;
			double totalInterest = totalPayment - principalAmount;

			// Sonuçlarý göster
			ResultLabel.Text = $"Aylýk Taksit: {installment:F2} TL\n" +
							   $"Toplam Ödeme: {totalPayment:F2} TL\n" +
							   $"Toplam Faiz: {totalInterest:F2} TL";
		}
		catch (Exception)
		{
			await DisplayAlert("Hata", "Lütfen tüm alanlarý eksiksiz ve doðru doldurun.", "Tamam");
		}
	}
}