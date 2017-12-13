using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Threading;

namespace Module_Accounting
{
    /// <summary>
    /// Interaction logic for Accounting.xaml
    /// </summary>
    public partial class Accounting : Window
    {
        private static string dbLocation = "server=localhost;user id=root;database=capstone_sis";
        private string dbQuery;
        private string _studentNumber;

        public Accounting(string studentNumber)
        {
            InitializeComponent();

            _studentNumber = studentNumber;

            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            db_DisplayStudentInformation(_studentNumber);
            db_CheckForBalances(_studentNumber);
            db_DisplayPayments(_studentNumber);
            db_DisplayInstallments(_studentNumber);
        }

        private void db_DisplayStudentInformation(string studentNumber)
        {
            MySqlConnection dbConnection = new MySqlConnection(dbLocation);

            dbQuery = "SELECT student_number, CONCAT(last_name, ' ', first_name), grade_level, section FROM students WHERE student_number = '" + studentNumber.ToString() + "'";

            MySqlCommand dbCommand = new MySqlCommand(dbQuery, dbConnection);

            try
            {
                dbConnection.Open();

                MySqlDataReader dbDataReader = dbCommand.ExecuteReader();

                if (dbDataReader.Read() == true)
                {
                    lbl_StudentNumber.Text = dbDataReader.GetValue(0).ToString();
                    lbl_StudentName.Text = dbDataReader.GetValue(1).ToString();
                    lbl_GradeLevel.Text = dbDataReader.GetValue(2).ToString();
                    lbl_Section.Text = dbDataReader.GetValue(3).ToString();

                    dbConnection.Close();
                }

                else
                {
                    dbConnection.Close();
                }
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
        
        private void db_CheckForBalances(string studentNumber)
        {
            MySqlConnection dbConnection = new MySqlConnection(dbLocation);

            dbQuery = "SELECT COUNT(balances.fee_type) FROM balances WHERE balances.remaining > 0 AND balances.student_number = '" + studentNumber.ToString() + "'";

            MySqlCommand dbCommand = new MySqlCommand(dbQuery, dbConnection);

            try
            {
                dbConnection.Open();

                MySqlDataReader dbDataReader = dbCommand.ExecuteReader();

                if (dbDataReader.Read() == true)
                {
                    if (dbDataReader.GetValue(0).ToString() == "0")
                    {
                        f_Balances.NavigationService.Navigate(new Pages.WithoutBalance()); 

                        dbConnection.Close();
                    }

                    else
                    {
                        f_Balances.NavigationService.Navigate(new Pages.WithBalance(studentNumber));
                        
                        dbConnection.Close();
                    }
                }

                else
                {
                    dbConnection.Close();
                }
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
        
        private void db_DisplayPayments(string studentNumber)
        {
            dbQuery = "SELECT fee_type, payment_amount, remaining, remarks FROM payments WHERE student_number  = '" + studentNumber.ToString() + "'";

            MySqlConnection dbConnection = new MySqlConnection(dbLocation);
            MySqlCommand dbCommand = new MySqlCommand(dbQuery, dbConnection);

            try
            {
                dbConnection.Open();

                MySqlDataAdapter dbDataAdapter = new MySqlDataAdapter(dbCommand);

                DataTable dbDataTable = new DataTable("payments");
                dbDataAdapter.Fill(dbDataTable);
                dgv_Payments.ItemsSource = dbDataTable.DefaultView;

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

        private void db_DisplayInstallments(string studentNumber)
        {
            dbQuery = "SELECT count, installment_date, installment_amount FROM installments WHERE student_number = '" + studentNumber.ToString() + "'";

            MySqlConnection dbConnection = new MySqlConnection(dbLocation);
            MySqlCommand dbCommand = new MySqlCommand(dbQuery, dbConnection);

            try
            {
                dbConnection.Open();

                MySqlDataAdapter dbDataAdapter = new MySqlDataAdapter(dbCommand);

                DataTable dbDataTable = new DataTable("installments");
                dbDataAdapter.Fill(dbDataTable);
                dgv_Installments.ItemsSource = dbDataTable.DefaultView;

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

        private void btn_CurrentPayments_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_ArchivedPayments_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
