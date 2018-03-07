using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace CRUD_School_System
{
    /// <summary>
    /// Interaction logic for StudentsPage.xaml
    /// </summary>
    public partial class StudentsPage : Page
    {
        public StudentsPage()
        {
            InitializeComponent();
        }

        private void CourseViewer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SqlConnection connectionString = new SqlConnection("Data Source=MUNEERNOTEBOOK;Initial Catalog=School_System;Integrated Security=True");
            try
            {
                connectionString.Open();
                SqlCommand cmd = new SqlCommand("Select * from Courses", connectionString);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adopter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable("Courses");
                adopter.Fill(table);
                CourseViewer.ItemsSource = table.DefaultView;
                adopter.Update(table);
                connectionString.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GradesViewer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SqlConnection connectionString = new SqlConnection("Data Source=MUNEERNOTEBOOK;Initial Catalog=School_System;Integrated Security=True");
            try
            {
                connectionString.Open();
                SqlCommand cmd = new SqlCommand("Select * from Grades", connectionString);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adopter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable("Grades");
                adopter.Fill(table);
                GradesViewer.ItemsSource = table.DefaultView;
                adopter.Update(table);
                connectionString.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GoToMain_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
        }
    }
}
