namespace AraOdev;

public partial class Renk_Secım : ContentPage
{
    public Renk_Secım()
    {
        InitializeComponent();
    }
      
         private void OnGenerateColorButtonClicked(object sender, EventArgs e)
            {
              
                int red = (int)RedSlider.Value;
                int green = (int)GreenSlider.Value;
                int blue = (int)BlueSlider.Value;

   
                Color selectedColor = Color.FromRgb(red, green, blue);
                SelectedColorBox.Color = selectedColor;

             
                ColorCodeLabel.Text = $"Renk Kodu: #{red:X2}{green:X2}{blue:X2}";
            }
}
