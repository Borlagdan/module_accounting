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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace Module_Accounting.Pages
{
    /// <summary>
    /// Interaction logic for Installments.xaml
    /// </summary>
    public partial class Installments : Page
    {
        private static string dbLocation = "server=localhost;user id=root;database=capstone_sis";
        private string dbQuery;
        private string _studentNumber;

        public Installments(string balanceNumber, string studentNumber)
        {
            InitializeComponent();

            _studentNumber = studentNumber;

            db_DisplayPaymentInformation(balanceNumber, studentNumber);
        }

        private void btn_Confirm_Click(object sender, RoutedEventArgs e)
        {
            db_CheckInstallmentRecord(_studentNumber);
        }

        private void db_DisplayPaymentInformation(string balanceNumber, string studentNumber)
        {
            MySqlConnection dbConnection = new MySqlConnection(dbLocation);

            dbQuery = "SELECT fee_type, remaining FROM balances WHERE remaining > 0 AND balance_number = '" + balanceNumber.ToString() + "' AND student_number = '" + studentNumber.ToString() + "'";

            MySqlCommand dbCommand = new MySqlCommand(dbQuery, dbConnection);

            try
            {
                dbConnection.Open();

                MySqlDataReader dbDataReader = dbCommand.ExecuteReader();

                if (dbDataReader.Read() == true)
                {
                    lbl_Fee.Text = dbDataReader.GetValue(0).ToString();
                    lbl_Amount.Text = dbDataReader.GetValue(1).ToString();

                    txt_Amount.Focus();

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

        private void db_CheckInstallmentRecord(string _studentNumber)
        {
            MySqlConnection dbConnection = new MySqlConnection(dbLocation);

            dbQuery = "SELECT count(fee_type) FROM installments WHERE school_year = '2017-2018' AND fee_type = '" + lbl_Fee.Text + "' AND student_number = '" + _studentNumber.ToString() + "'";

            MySqlCommand dbCommand = new MySqlCommand(dbQuery, dbConnection);

            try
            {
                dbConnection.Open();

                MySqlDataReader dbDataReader = dbCommand.ExecuteReader();

                if (dbDataReader.Read() == true)
                {
                    if (dbDataReader.GetValue(0).ToString() == "0")
                    {
                        dbConnection.Close();

                        db_AddInstallmentRecord(_studentNumber);
                        // MessageBox.Show("Installment record not found", "Record", MessageBoxButton.OK);
                    }

                    else
                    {
                        dbConnection.Close();

                        db_GetRecordInformation(_studentNumber);
                        // MessageBox.Show("Installment record found", "Record", MessageBoxButton.OK);
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
        
        private void db_AddInstallmentRecord(string _studentNumber)
        {
            dbQuery = "INSERT INTO installments (school_year, quarter, installment_number, count, assessed_by, student_number, installment_date, fee_type, fee_amount, cash_amount, installment_amount, change_amount, remaining, total, remarks) VALUES (@school_year, @quarter, @installment_number, @count, @assessed_by, @student_number, @installment_date, @fee_type, @fee_amount, @cash_amount, @installment_amount, @change_amount, @remaining, @total, @remarks)";

            MySqlConnection dbConnection = new MySqlConnection(dbLocation);
            MySqlCommand dbCommand = new MySqlCommand(dbQuery, dbConnection);

            dbCommand.Parameters.AddWithValue("@school_year", "2017-2018");
            dbCommand.Parameters.AddWithValue("@quarter", "1ST");
            dbCommand.Parameters.AddWithValue("@installment_number", "I_0002");
            dbCommand.Parameters.AddWithValue("@count", "1");
            dbCommand.Parameters.AddWithValue("@assessed_by", "Admin");
            dbCommand.Parameters.AddWithValue("@student_number", _studentNumber.ToString());
            dbCommand.Parameters.AddWithValue("@installment_date", DateTime.Today.Date.ToString("MM/dd/yyyy"));
            dbCommand.Parameters.AddWithValue("@fee_type", lbl_Fee.Text);
            dbCommand.Parameters.AddWithValue("@fee_amount", lbl_Amount.Text);
            dbCommand.Parameters.AddWithValue("@cash_amount", txt_Cash.Text);
            dbCommand.Parameters.AddWithValue("@installment_amount", txt_Amount.Text);
            dbCommand.Parameters.AddWithValue("@change_amount", lbl_Change.Text);
            dbCommand.Parameters.AddWithValue("@remaining", lbl_Balance.Text);
            dbCommand.Parameters.AddWithValue("@total", lbl_Total.Text);
            dbCommand.Parameters.AddWithValue("@remarks", "Payment incomplete");

            try
            {
                dbConnection.Open();
                
                if (dbCommand.ExecuteNonQuery() > 0)
                {
                    dbConnection.Close();

                    string _payment_date = DateTime.Today.Date.ToString("MM/dd/yyyy");
                    double _remaining = double.Parse(lbl_Balance.Text);
                    double _total = double.Parse(lbl_Total.Text);
                    string _status = "Payment incomplete";
                    
                    db_UpdateBalanceRecords(_payment_date, _remaining, _status);
                    db_AddPaymentRecord(_studentNumber, _remaining, _total, _status);
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
        
        private void db_GetRecordInformation(string _studentNumber)
        {
            MySqlConnection dbConnection = new MySqlConnection(dbLocation);

            dbQuery = "SELECT count, remaining, total FROM installments WHERE school_year = '2017-2018' AND fee_type = '" + lbl_Fee.Text + "' AND student_number = '" + _studentNumber.ToString() + "'";

            MySqlCommand dbCommand = new MySqlCommand(dbQuery, dbConnection);

            try
            {
                dbConnection.Open();

                MySqlDataReader dbDataReader = dbCommand.ExecuteReader();

                if (dbDataReader.Read() == true)
                {
                    int count = int.Parse(dbDataReader.GetValue(0).ToString());
                    double remaining = double.Parse(dbDataReader.GetValue(1).ToString());
                    double total = double.Parse(dbDataReader.GetValue(2).ToString());
                    
                    dbConnection.Close();

                    db_AdjustRecords(count, remaining, total);
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

        private void db_AdjustRecords(int count, double remaining, double total)
        {
            int _count;
            double _remaining;
            double _total;
            string _remarks;

            _count = count + 1;
            _remaining = remaining - double.Parse(txt_Amount.Text);
            _total = total + double.Parse(lbl_Total.Text);

            if(_total < _remaining)
            {
                _remarks = "Payment incomplete";
            }

            else
            {
                _remarks = "Fully paid";
            }
            
            db_ContinueInstallmentRecord(_count, _remaining, _total, _remarks);
            db_AddPaymentRecord(_studentNumber, _remaining, _total, _remarks);
        }

        private void db_ContinueInstallmentRecord(int _count, double _remaining, double _total, string _remarks)
        {
            dbQuery = "INSERT INTO installments (school_year, quarter, installment_number, count, assessed_by, student_number, installment_date, fee_type, fee_amount, cash_amount, installment_amount, change_amount, remaining, total, remarks) VALUES (@school_year, @quarter, @installment_number, @count, @assessed_by, @student_number, @installment_date, @fee_type, @fee_amount, @cash_amount, @installment_amount, @change_amount, @remaining, @total, @remarks)";

            MySqlConnection dbConnection = new MySqlConnection(dbLocation);
            MySqlCommand dbCommand = new MySqlCommand(dbQuery, dbConnection);

            dbCommand.Parameters.AddWithValue("@school_year", "2017-2018");
            dbCommand.Parameters.AddWithValue("@quarter", "1ST");
            dbCommand.Parameters.AddWithValue("@installment_number", "I_0002");
            dbCommand.Parameters.AddWithValue("@count", _count.ToString());
            dbCommand.Parameters.AddWithValue("@assessed_by", "Admin");
            dbCommand.Parameters.AddWithValue("@student_number", _studentNumber.ToString());
            dbCommand.Parameters.AddWithValue("@installment_date", DateTime.Today.Date.ToString("MM/dd/yyyy"));
            dbCommand.Parameters.AddWithValue("@fee_type", lbl_Fee.Text);
            dbCommand.Parameters.AddWithValue("@fee_amount", lbl_Amount.Text);
            dbCommand.Parameters.AddWithValue("@cash_amount", txt_Cash.Text);
            dbCommand.Parameters.AddWithValue("@installment_amount", txt_Amount.Text);
            dbCommand.Parameters.AddWithValue("@change_amount", lbl_Change.Text);
            dbCommand.Parameters.AddWithValue("@remaining", _remaining.ToString());
            dbCommand.Parameters.AddWithValue("@total", _total.ToString());
            dbCommand.Parameters.AddWithValue("@remarks", _remarks.ToString());

            try
            {
                dbConnection.Open();
                
                if (dbCommand.ExecuteNonQuery() > 0)
                {
                    dbConnection.Close();
                    
                    db_UpdateBalanceRecords(DateTime.Today.Date.ToString("MM/dd/yyyy"), _remaining, _remarks);
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

        private void db_UpdateBalanceRecords(string _payment_date, double _remaining, string _status)
        {
            dbQuery = "UPDATE balances SET assessed_by = 'Admin', payment_date = '" + _payment_date.ToString() + "', remaining = " + _remaining.ToString() + ", status = '" + _status + "' WHERE balance_number = 'B_0004' AND fee_type = 'Tuition' AND student_number = '" + _studentNumber.ToString() + "'";

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

        private void txt_Amount_TextChanged(object sender, TextChangedEventArgs e)
        {
            int FeeAmount = 0;
            int Amount = 0;
            int Cash = 0;
            int Change = 0;
            int Balance = 0;

            if (txt_Cash.Text != "")
            {
                lbl_Change.Text = "0";

                if (txt_Cash.Text != "")
                {
                    FeeAmount = int.Parse(lbl_Amount.Text);
                    Amount = int.Parse(txt_Amount.Text);
                    Cash = int.Parse(txt_Cash.Text);

                    if (Amount == 0)
                    {
                        lbl_Change.Text = "0";
                        lbl_Total.Text = "0";
                    }
                    else if (Amount > Cash)
                    {
                        lbl_Change.Text = "0";
                    }
                    else
                    {
                        Change = Cash - Amount;
                        Balance = FeeAmount - Amount;

                        lbl_Change.Text = Change.ToString();
                        lbl_Balance.Text = Balance.ToString();
                        lbl_Total.Text = Amount.ToString();
                    }
                }
            }
        }

        private void txt_Cash_TextChanged(object sender, TextChangedEventArgs e)
        {
            int FeeAmount = 0;
            int Amount = 0;
            int Cash = 0;
            int Change = 0;
            int Balance = 0;

            if (txt_Cash.Text != "")
            {
                lbl_Change.Text = "0";

                if (txt_Cash.Text != "")
                {
                    FeeAmount = int.Parse(lbl_Amount.Text);
                    Amount = int.Parse(txt_Amount.Text);
                    Cash = int.Parse(txt_Cash.Text);

                    if (Amount == 0)
                    {
                        lbl_Change.Text = "0";
                        lbl_Total.Text = "0";
                    }
                    else if (Amount > Cash)
                    {
                        lbl_Change.Text = "0";
                    }
                    else
                    {
                        Change = Cash - Amount;
                        Balance = FeeAmount - Amount;

                        lbl_Change.Text = Change.ToString();
                        lbl_Balance.Text = Balance.ToString();
                        lbl_Total.Text = Amount.ToString();
                    }
                }
            }
        }

        private void db_AddPaymentRecord(string _studentNumber, double _remaining, double _total, string _remarks)
        {
            dbQuery = "INSERT INTO payments (payment_number, school_year, quarter, assessed_by, payment_date, student_number, fee_type, fee_amount, payment_amount, remaining, total, remarks) VALUES (@payment_number, @school_year, @quarter, @assessed_by, @payment_date, @student_number, @fee_type, @fee_amount, @payment_amount, @remaining, @total, @remarks)";

            MySqlConnection dbConnection = new MySqlConnection(dbLocation);
            MySqlCommand dbCommand = new MySqlCommand(dbQuery, dbConnection);

            dbCommand.Parameters.AddWithValue("@payment_number", "P_0003");
            dbCommand.Parameters.AddWithValue("@school_year", "2017-2018");
            dbCommand.Parameters.AddWithValue("@quarter", "1ST");
            dbCommand.Parameters.AddWithValue("@assessed_by", "Admin");
            dbCommand.Parameters.AddWithValue("@payment_date", DateTime.Today.Date.ToString("MM/dd/yyyy"));
            dbCommand.Parameters.AddWithValue("@student_number", _studentNumber.ToString());
            dbCommand.Parameters.AddWithValue("@fee_type", lbl_Fee.Text);
            dbCommand.Parameters.AddWithValue("@fee_amount", txt_Amount.Text);
            dbCommand.Parameters.AddWithValue("@payment_amount", txt_Cash.Text);
            dbCommand.Parameters.AddWithValue("@remaining", _remaining.ToString());
            dbCommand.Parameters.AddWithValue("@total", _total.ToString());
            dbCommand.Parameters.AddWithValue("@remarks", _remarks.ToString());

            try
            {
                dbConnection.Open();

                if (dbCommand.ExecuteNonQuery() > 0)
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
    }
}
