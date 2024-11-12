using System;
using Microsoft.Maui.Controls;
namespace AraOdev;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
		InitializeComponent();


        
        WeightSlider.Value = 70; 
        HeightSlider.Value = 170; 
    }

   
    private void OnWeightSliderChanged(object sender, ValueChangedEventArgs e)
    {
        WeightEntry.Text = ((int)e.NewValue).ToString();
    }

    
    private void OnHeightSliderChanged(object sender, ValueChangedEventArgs e)
    {
        HeightEntry.Text = ((int)e.NewValue).ToString();
    }

  
    private void OnCalculateButtonClicked(object sender, EventArgs e)
    {
        if (double.TryParse(WeightEntry.Text, out double weight) &&
            double.TryParse(HeightEntry.Text, out double height))
        {
            height /= 100; 

            double bmi = weight / (height * height);

            string category;
            if (bmi < 16)
                category = "Ýleri Düzeyde Zayýf";
            else if (bmi >= 16 && bmi <= 16.99)
                category = "Orta Düzeyde Zayýf";
            else if (bmi >= 17 && bmi <= 18.49)
                category = "Hafif Düzeyde Zayýf";
            else if (bmi >= 18.5 && bmi <= 24.9)
                category = "Normal Kilolu";
            else if (bmi >= 25 && bmi <= 29.99)
                category = "Hafif Þiþman / Fazla Kilolu";
            else if (bmi >= 30 && bmi <= 34.99)
                category = "1. Derecede Obez";
            else if (bmi >= 35 && bmi <= 39.99)
                category = "2. Derecede Obez";
            else
                category = "3. Derecede Obez / Morbid Obez";

            ResultLabel.Text = $"VKI: {bmi:F2} - {category}";
        }
        else
        {
            ResultLabel.Text = "Lütfen geçerli kilo ve boy giriniz.";
        }
    }
}
