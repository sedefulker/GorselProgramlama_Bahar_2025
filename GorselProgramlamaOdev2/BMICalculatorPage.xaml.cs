namespace GorselProgramlamaOdev2;

public partial class BMICalculatorPage : ContentPage
{
	public BMICalculatorPage()
	{
		InitializeComponent();
		WeightSlider.Value = 70;
		HeightSlider.Value = 170;

		WeightLabel.Text = $"Kilo: {WeightSlider.Value} kg";
		HeightLabel.Text = $"Boy: {HeightSlider.Value} cm";
	}

	private void OnWeightChanged(object sender, ValueChangedEventArgs e)
	{
		WeightLabel.Text = $"Kilo: {e.NewValue:F0} kg";
		UpdateBMI();
	}

	private void OnHeightChanged(object sender, ValueChangedEventArgs e)
	{
		HeightLabel.Text = $"Boy: {e.NewValue:F0} cm";
		UpdateBMI();
	}

	private void UpdateBMI()
	{
		double weight = WeightSlider.Value;
		double height = HeightSlider.Value / 100;
		double bmi = weight / (height * height);

		string category;

		if (bmi < 16)
			category = "Ýleri Düzeyde Zayýf";
		else if (bmi < 17)
			category = "Orta Düzeyde Zayýf";
		else if (bmi < 18.5)
			category = "Hafif Düzeyde Zayýf";
		else if (bmi < 25)
			category = "Normal Kilolu";
		else if (bmi < 30)
			category = "Fazla Kilolu";
		else if (bmi < 35)
			category = "1. Derecede Obez";
		else if (bmi < 40)
			category = "2. Derecede Obez";
		else
			category = "3. Derecede Obez / Morbid Obez";

		BMIResultLabel.Text = $"VKÝ: {bmi:F2} - {category}";
		BMIResultLabel.TextColor = Colors.White; 
	}
}