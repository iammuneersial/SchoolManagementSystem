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
using System.Data.SqlClient;
using System.Data;

namespace CRUD_School_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;


        }
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.MinWidth = this.Width;
            this.MinHeight = this.Height;
        }
        
        private void Administrator_Click(object sender, RoutedEventArgs e)
        {
            //For Administrator Login
            try
            {
                string connectionString = null;
                connectionString = @"Data Source=MUNEERNOTEBOOK;Initial Catalog=School_System;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("Select Count(*) From Administrator where USERNAME = '" + textBox.Text + "' and PASSWORD = '" + passwordBox.Password + "'", connection);
                    DataTable dataTable = new DataTable(); //this is creating a virtual table  
                    adapter.Fill(dataTable);
                    if (dataTable.Rows[0][0].ToString() == "1")
                    {
                        AdministratorPage adm = new AdministratorPage();
                        this.Content = adm;
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password");    
                    }
                }
            }

            catch (Exception exc)
            {
                MessageBox.Show("Exception : " + exc);
            }
            
        }

        private void hide()
        {
            throw new NotImplementedException();
        }

        private void Teacher_Click(object sender, RoutedEventArgs e)
        {
            //For Teacher Login
            try
            {
                string connectionString = null;
                connectionString = @"Data Source=MUNEERNOTEBOOK;Initial Catalog=School_System;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("Select Count(*) From Teacher where Name = '" + textBox.Text + "' and Password = '" + passwordBox.Password + "'", connection);
                    DataTable dataTable = new DataTable(); //this is creating a virtual table  
                    adapter.Fill(dataTable);
                    if (dataTable.Rows[0][0].ToString() == "1")
                    {
                        TeacherPage tchr = new TeacherPage();
                        this.Content = tchr;
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password");
                    }
                }
            }

            catch (Exception exc)
            {
                MessageBox.Show("Exception : " + exc);
            }
        }

        private void Student_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectionString = null;
                connectionString = @"Data Source=MUNEERNOTEBOOK;Initial Catalog=School_System;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("Select Count(*) From Students where Name = '" + textBox.Text + "' and Password = '" + passwordBox.Password + "'", connection);
                    DataTable dataTable = new DataTable(); //this is creating a virtual table  
                    adapter.Fill(dataTable);
                    if (dataTable.Rows[0][0].ToString() == "1")
                    {
                        StudentsPage sp = new StudentsPage();
                        this.Content = sp;
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password");
                    }
                }
            }

            catch (Exception exc)
            {
                MessageBox.Show("Exception : " + exc);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
