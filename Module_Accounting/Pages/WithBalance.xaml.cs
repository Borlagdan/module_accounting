using System.Data;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace Module_Accounting.Pages
{
    /// <summary>
    /// Interaction logic for WithBalance.xaml
    /// </summary>
    public partial class WithBalance : Page
    {
        private static string dbLocation = "server=localhost;user id=root;database=capstone_sis";
        private string dbQuery;
        private string studentNumber;

        public WithBalance(string _studentNumber)
        {
            InitializeComponent();

            studentNumber = _studentNumber;
            
            db_DisplayBalances(studentNumber);
        }
        
        private void btn_Full_Click(object sender, RoutedEventArgs e)
        {
            DataRowView rowView = dgv_Balances.SelectedItem as DataRowView;
            string balanceNumber = rowView.Row[0].ToString();

            string paymentOption = "Full";

            Payment _payment = new Payment(balanceNumber, studentNumber, paymentOption);
            _payment.Show();
        }

        private void btn_Installments_Click(object sender, RoutedEventArgs e)
        {
            DataRowView rowView = dgv_Balances.SelectedItem as DataRowView;
            string balanceNumber = rowView.Row[0].ToString();

            string paymentOption = "Installments";

            Payment _payment = new Payment(balanceNumber, studentNumber, paymentOption);
            _payment.Show();
        }
        
        public void db_DisplayBalances(string studentNumber)
        {
            dbQuery = "SELECT balance_number, fee_type, remaining FROM balances WHERE remaining > 0 AND student_number = '" + studentNumber + "'";

            MySqlConnection dbConnection = new MySqlConnection(dbLocation);
            MySqlCommand dbCommand = new MySqlCommand(dbQuery, dbConnection);

            try
            {
                dbConnection.Open();

                MySqlDataAdapter dbDataAdapter = new MySqlDataAdapter(dbCommand);

                DataTable dbDataTable = new DataTable("balances");
                dbDataAdapter.Fill(dbDataTable);
                dgv_Balances.ItemsSource = dbDataTable.DefaultView;

                dbConnection.Close();
            }

            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message);
                dbConnection.Close();
            }

            finally
            {
                dbConnection.Close();
            }
        }
    }
}
