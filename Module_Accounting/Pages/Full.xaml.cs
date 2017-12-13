using System;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace Module_Accounting.Pages
{
    /// <summary>
    /// Interaction logic for Full.xaml
    /// </summary>
    public partial class Full : Page
    {
        private static string dbLocation = "server=localhost;user id=root;database=capstone_sis";
        private string dbQuery;
        private string _studentNumber;

        public Full(string balanceNumber, string studentNumber)
        {
            InitializeComponent();

            db_DisplayPaymentInformation(balanceNumber, studentNumber);

            txt_Cash.Focus();

            _studentNumber = studentNumber;
        }

        private void db_DisplayPaymentInformation(string balanceNumber, string studentNumber)
        {
            MySqlConnection dbConnection = new MySqlConnection(dbLocation);

            dbQuery = "SELECT fee_type, amount FROM balances WHERE remaining > 0 AND balance_number = '" + balanceNumber.ToString() + "' AND student_number = '" + studentNumber.ToString() + "'";

            MySqlCommand dbCommand = new MySqlCommand(dbQuery, dbConnection);

            try
            {
                dbConnection.Open();

                MySqlDataReader dbDataReader = dbCommand.ExecuteReader();

                if (dbDataReader.Read() == true)
                {
                    lbl_Fee.Text = dbDataReader.GetValue(0).ToString();
                    lbl_Amount.Text = dbDataReader.GetValue(1).ToString();
                    txt_Amount.Text = dbDataReader.GetValue(1).ToString();

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


        private void txt_Cash_TextChanged(object sender, TextChangedEventArgs e)
        {
            Compute();
        }

        private void Compute()
        {
            int Amount = 0;
            int Cash = 0;
            int Change = 0;

            if (txt_Cash.Text != "")
            {
                lbl_Change.Text = "0";

                if (txt_Cash.Text != "")
                {
                    Amount = int.Parse(txt_Amount.Text);
                    Cash = int.Parse(txt_Cash.Text);

                    if (Amount == 0)
                    {
                        lbl_Change.Text = "0";
                    }
                    else if (Amount > Cash)
                    {
                        lbl_Change.Text = "0";
                    }
                    else
                    {
                        Change = Cash - Amount;

                        lbl_Change.Text = Change.ToString();
                        lbl_Total.Text = lbl_Amount.Text;
                    }
                }
            }
        }

        private void db_UpdateBalance()
        {
            dbQuery = "UPDATE balances SET assessed_by = 'Admin', payment_date = '12/12/2017', student_number = '" + _studentNumber.ToString() + "', fee_type = '" + lbl_Fee.Text + "', amount = '" + lbl_Amount.Text + "', remaining = '" + lbl_Balance.Text + "', status = 'Fully paid' WHERE balance_number = 'B_0001' AND fee_type = '" + lbl_Fee.Text + "' AND student_number = '" + _studentNumber.ToString() + "'";

            MySqlConnection dbConnection = new MySqlConnection(dbLocation);
            MySqlCommand dbCommand = new MySqlCommand(dbQuery, dbConnection);

            try
            {
                dbConnection.Open();

                MySqlDataReader dbDataReader = dbCommand.ExecuteReader();

                if (dbDataReader.Read() == true)
                {
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

        private void db_Pay()
        {
            dbQuery = "INSERT INTO payments (payment_number, school_year, quarter, assessed_by, payment_date, student_number, fee_type, fee_amount, payment_amount, remaining, total, remarks) VALUES (@payment_number, @school_year, @quarter, @assessed_by, @payment_date, @student_number, @fee_type, @fee_amount, @payment_amount, @remaining, @total, @remarks)";

            MySqlConnection dbConnection = new MySqlConnection(dbLocation);
            MySqlCommand dbCommand = new MySqlCommand(dbQuery, dbConnection);
            
            dbCommand.Parameters.AddWithValue("@payment_number", "P_0001");
            dbCommand.Parameters.AddWithValue("@school_year", "2017-2018");
            dbCommand.Parameters.AddWithValue("@quarter", "1ST");
            dbCommand.Parameters.AddWithValue("@assessed_by", "Admin");
            dbCommand.Parameters.AddWithValue("@payment_date", DateTime.Today.Date.ToString("MM/dd/yyyy"));

            dbCommand.Parameters.AddWithValue("@student_number", _studentNumber.ToString());
            dbCommand.Parameters.AddWithValue("@fee_type", lbl_Fee.Text);
            dbCommand.Parameters.AddWithValue("@fee_amount", lbl_Amount);
            dbCommand.Parameters.AddWithValue("@payment_amount", txt_Amount.Text);
            dbCommand.Parameters.AddWithValue("@remaining", lbl_Total.Text);
            dbCommand.Parameters.AddWithValue("@total", lbl_Total.Text);
            dbCommand.Parameters.AddWithValue("@remarks", "Fully paid");
            
            try
            {
                dbConnection.Open();

                MySqlDataReader dbDataReader = dbCommand.ExecuteReader();

                if (dbDataReader.Read() == true)
                {
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

        

        private void btn_Confirm_Click(object sender, RoutedEventArgs e)
        {
            db_UpdateBalance();
            db_Pay();
        }
    }
}
