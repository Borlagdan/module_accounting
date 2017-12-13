using MahApps.Metro.Controls;

namespace Module_Accounting.Pages
{
    /// <summary>
    /// Interaction logic for Payment.xaml
    /// </summary>
    public partial class Payment : MetroWindow
    {
        public Payment(string balanceNumber, string studentNumber, string paymentOption)
        {
            InitializeComponent();

            checkPaymentOption(balanceNumber, studentNumber, paymentOption);
        }

        private void checkPaymentOption(string balanceNumber, string studentNumber, string paymentOption)
        {
            if (paymentOption == "Full")
            {
                f_Payment.NavigationService.Navigate(new Pages.Full(balanceNumber, studentNumber));
            }

            else if (paymentOption == "Installments")
            {
                f_Payment.NavigationService.Navigate(new Pages.Installments(balanceNumber, studentNumber));
            }
        }

        
    }
}
