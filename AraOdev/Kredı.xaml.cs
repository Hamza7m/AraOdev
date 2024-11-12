namespace AraOdev;

public partial class Kredı : ContentPage
{
	public Kredı()
	{
		InitializeComponent();
	}
    private void OnCalculateButtonClicked(object sender, EventArgs e)
    {

        if (double.TryParse(AmountEntry.Text, out double amount) &&
            double.TryParse(InterestRateEntry.Text, out double interestRate) &&
            int.TryParse(TermEntry.Text, out int term) &&
            LoanTypePicker.SelectedItem != null)
        {
            
            double kkdf = 0, bsmv = 0;
            string loanType = LoanTypePicker.SelectedItem.ToString();

            switch (loanType)
            {
                case "İhtiyaç":
                    kkdf = 0.15; // %15 KKDF
                    bsmv = 0.10; // %10 BSMV
                    break;
                case "Konut":
                    kkdf = 0.0;
                    bsmv = 0.06;
                    break;
                case "Taşıt":
                    kkdf = 0.15;
                    bsmv = 0.05;
                    break;
                case "Ticari":
                    kkdf = 0.0;
                    bsmv = 0.05;
                    break;
            }

         
            double monthlyInterestRate = (interestRate / 100) * (1 + kkdf + bsmv);
            double totalMonthlyRate = Math.Pow(1 + monthlyInterestRate, term);
            double monthlyPayment = (amount * monthlyInterestRate * totalMonthlyRate) / (totalMonthlyRate - 1);

          
            double totalPayment = monthlyPayment * term;
            double totalInterest = totalPayment - amount;

            MonthlyPaymentLabel.Text = $"{monthlyPayment:F2} TL";
            TotalPaymentLabel.Text = $"{totalPayment:F2} TL";
            TotalInterestLabel.Text = $"{totalInterest:F2} TL";
        }
        else
        {
            DisplayAlert("Hata", "Lütfen tüm alanları doğru doldurunuz.", "Tamam");
        }
    }
}