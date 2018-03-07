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
    /// Interaction logic for TeacherPage.xaml
    /// </summary>
    public partial class TeacherPage : Page
    {
        public TeacherPage()
        {
            InitializeComponent();
        }

        private void enterEmpID_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connectionString = new SqlConnection("Data Source=MUNEERNOTEBOOK;Initial Catalog=School_System;Integrated Security=True");
            try
            {
                connectionString.Open();
                SqlCommand cmd = new SqlCommand("select Salary from Teacher where EmployeeID = '" + takeEmpID.Text + "'", connectionString);
                if (takeEmpID.Text == "")
                {
                    MessageBox.Show("Please enter Correct Employee ID");
                }
                else
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    dispSalary.Content = reader["Salary"].ToString();
                    connectionString.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddGrade_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connectionString = new SqlConnection("Data Source=MUNEERNOTEBOOK;Initial Catalog=School_System;Integrated Security=True");
            try
            {
                connectionString.Open();
                SqlCommand cmd = new SqlCommand("insert into Grades(RegID,CourseID,Grade) values('" + getStRegID.Text + "','" + getCourseID.Text + "','" + getGrade.Text + "')", connectionString);
                if (getStRegID.Text == "" || getCourseID.Text == "" || getGrade.Text == "")
                {
                    MessageBox.Show("Please enter correct values in textboxes!!!");
                }
                else
                {
                    cmd.ExecuteNonQuery();
                    getStRegID.Text = "";
                    getCourseID.Text = "";
                    getGrade.Text = "";
                    MessageBox.Show("Grade added");
                    connectionString.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CourseView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
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
                CourseView.ItemsSource = table.DefaultView;
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
