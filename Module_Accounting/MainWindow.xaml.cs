using System.Windows;
using System.Data;
using MySql.Data.MySqlClient;

namespace Module_Accounting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string dbLocation = "server=localhost;user id=root;database=capstone_sis";
        private string dbQuery;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db_DisplayStudentList();

            db_DisplayTotalStudents();
            db_DisplayPaidStudents();
            db_DisplayUnPaidStudents();
        }

        private void btn_View_Click(object sender, RoutedEventArgs e)
        {
            DataRowView rowView = dgv_Records.SelectedItem as DataRowView;
            string studentNumber = rowView.Row[2].ToString();

            Accounting _accounting = new Accounting(studentNumber);
            _accounting.Show();

            this.Close();

        }

        private void btn_Update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void db_DisplayStudentList()
        {
            dbQuery = "SELECT grade_level, section, student_number, last_name, first_name FROM students";

            MySqlConnection dbConnection = new MySqlConnection(dbLocation);
            MySqlCommand dbCommand = new MySqlCommand(dbQuery, dbConnection);

            try
            {
                dbConnection.Open();

                MySqlDataAdapter dbDataAdapter = new MySqlDataAdapter(dbCommand);

                DataTable dbDataTable = new DataTable("balances");
                dbDataAdapter.Fill(dbDataTable);
                dgv_Records.ItemsSource = dbDataTable.DefaultView;

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

        private void db_DisplayTotalStudents()
        {
            MySqlConnection dbConnection = new MySqlConnection(dbLocation);

            dbQuery = "SELECT COUNT(student_number) FROM students";

            MySqlCommand dbCommand = new MySqlCommand(dbQuery, dbConnection);

            try
            {
                dbConnection.Open();

                MySqlDataReader dbDataReader = dbCommand.ExecuteReader();

                if (dbDataReader.Read() == true)
                {
                    lbl_TotalStudents.Text = dbDataReader.GetValue(0).ToString();

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

        private void db_DisplayPaidStudents()
        {
            MySqlConnection dbConnection = new MySqlConnection(dbLocation);

            dbQuery = "SELECT COUNT(DISTINCT balances.student_number) FROM balances, students WHERE remaining = 0 AND balances.student_number = students.student_number";

            MySqlCommand dbCommand = new MySqlCommand(dbQuery, dbConnection);

            try
            {
                dbConnection.Open();

                MySqlDataReader dbDataReader = dbCommand.ExecuteReader();

                if (dbDataReader.Read() == true)
                {
                    lbl_PaidStudents.Text = dbDataReader.GetValue(0).ToString();

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

        private void db_DisplayUnPaidStudents()
        {
            MySqlConnection dbConnection = new MySqlConnection(dbLocation);

            dbQuery = "SELECT COUNT(DISTINCT balances.student_number) FROM balances, students WHERE remaining > 0 AND balances.student_number = students.student_number";

            MySqlCommand dbCommand = new MySqlCommand(dbQuery, dbConnection);

            try
            {
                dbConnection.Open();

                MySqlDataReader dbDataReader = dbCommand.ExecuteReader();

                if (dbDataReader.Read() == true)
                {
                    lbl_UnPaidStudents.Text = dbDataReader.GetValue(0).ToString();

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
