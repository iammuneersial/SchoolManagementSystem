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
using CRUD_School_System;
using System.Data.SqlClient;
using System.Data;

namespace CRUD_School_System
{
    /// <summary>
    /// Interaction logic for AdministratorPage.xaml
    /// </summary>
    public partial class AdministratorPage : Page
    {
        public AdministratorPage()
        {

            InitializeComponent();
        }

        private void AddingTeacher_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connectionString = new SqlConnection( "Data Source=MUNEERNOTEBOOK;Initial Catalog=School_System;Integrated Security=True");
            try
            {
                connectionString.Open();
                SqlCommand cmd = new SqlCommand("insert into Teacher(Name,Password,Salary,EmployeeID) values('"+ TeacherName.Text+ "','" + TeacherPassword.Text + "','" + Salary.Text + "','" + EmployeeID.Text + "')", connectionString);
                if (TeacherName.Text == "" || TeacherPassword.Text == ""|| Salary.Text == "" || EmployeeID.Text == "")
                {
                    MessageBox.Show("Please enter values in textboxes!!!");
                }
                else
                {
                    cmd.ExecuteNonQuery();
                    TeacherName.Text = "";
                    TeacherPassword.Text = "";
                    Salary.Text = "";
                    EmployeeID.Text = "";
                    MessageBox.Show("Teacher added");
                    connectionString.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {

            SqlConnection connectionString = new SqlConnection("Data Source=MUNEERNOTEBOOK;Initial Catalog=School_System;Integrated Security=True");
            try
            {
                connectionString.Open();
                if (txt_name.Text!="") {
                    if (MessageBox.Show("Are you sure to delete :" + txt_name.Text + "", "Message", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {


                        SqlCommand command = new SqlCommand("delete from Teacher where Name = '" + txt_name.Text + "'", connectionString);
                        command.ExecuteNonQuery();
                        SqlDataAdapter adopter = new SqlDataAdapter(command);
                        DataTable table = new DataTable("Teacher");
                        adopter.Fill(table);
                        datagrid.ItemsSource = table.DefaultView;
                        adopter.Update(table);
                        txt_name.Text = "";
                    }
                    else
                    {
                        connectionString.Close();
                        txt_name.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter Valid Name");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connectionString = new SqlConnection("Data Source=MUNEERNOTEBOOK;Initial Catalog=School_System;Integrated Security=True");
            try
            {
                connectionString.Open();
                SqlCommand cmd = new SqlCommand("insert into Students(Name,Password,RegID,Batch) values('" + StudentName.Text + "','" + StudentPassword.Text + "','" + Registration.Text + "','" + Batch.Text + "')", connectionString);
                if (StudentName.Text == "" || StudentPassword.Text == "" || Registration.Text == "" || Batch.Text == "")
                {
                    MessageBox.Show("Please enter values in textboxes!!!");
                }
                else
                {
                    cmd.ExecuteNonQuery();
                    StudentName.Text = "";
                    StudentPassword.Text = "";
                    Registration.Text = "";
                    Batch.Text = "";
                    MessageBox.Show("Student added");
                    connectionString.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void datagrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SqlConnection connectionString = new SqlConnection("Data Source=MUNEERNOTEBOOK;Initial Catalog=School_System;Integrated Security=True");
            try
            {
                connectionString.Open();
                SqlCommand command = new SqlCommand("Select * from Teacher ", connectionString);
                command.ExecuteNonQuery();
                SqlDataAdapter adopter = new SqlDataAdapter(command);
                DataTable table = new DataTable("Teacher");
                adopter.Fill(table);
                datagrid.ItemsSource = table.DefaultView;
                adopter.Update(table);
                connectionString.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void datagrid_For_Student_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            SqlConnection connectionString = new SqlConnection("Data Source=MUNEERNOTEBOOK;Initial Catalog=School_System;Integrated Security=True");
            try
            {
                connectionString.Open();
                SqlCommand cmd = new SqlCommand("Select * from Students ", connectionString);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adopter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable("Students");
                adopter.Fill(table);
                datagrid_For_Student.ItemsSource = table.DefaultView;
                adopter.Update(table);
                connectionString.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Delete_Student_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connectionString = new SqlConnection("Data Source=MUNEERNOTEBOOK;Initial Catalog=School_System;Integrated Security=True");
            try
            {
                if (txt_name_Student.Text!="") {
                connectionString.Open();
                if (MessageBox.Show("Are you sure to delete :" + txt_name_Student.Text + "", "Message", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {


                    SqlCommand command = new SqlCommand("delete from Students where Name = '" + txt_name_Student.Text + "'", connectionString);
                    command.ExecuteNonQuery();
                    SqlDataAdapter adopter = new SqlDataAdapter(command);
                    DataTable table = new DataTable("Students");
                    adopter.Fill(table);
                    datagrid_For_Student.ItemsSource = table.DefaultView;
                    adopter.Update(table);
                    txt_name_Student.Text = "";
                }
                else
                {
                    connectionString.Close();
                    txt_name_Student.Text = "";
                }
                }
                else
                {
                    MessageBox.Show("Please Enter Valid Name");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
        }
        */
        private void AddingBatch_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connectionString = new SqlConnection("Data Source=MUNEERNOTEBOOK;Initial Catalog=School_System;Integrated Security=True");
            try
            {
                connectionString.Open();
                SqlCommand cmd = new SqlCommand("insert into Batches(Batch,BatchName,BatchYear,BatchID) values('" + BatchShort.Text + "','" + BatchLong.Text + "','" + BatchyearFor.Text + "','" + BatchIDFor.Text + "')", connectionString);
                if (BatchShort.Text == "" || BatchLong.Text == "" || BatchyearFor.Text == "" || BatchIDFor.Text == "")
                {
                    MessageBox.Show("Please enter correct values in textboxes!!!");
                }
                else
                {
                    cmd.ExecuteNonQuery();
                    BatchShort.Text = "";
                    BatchLong.Text = "";
                    BatchyearFor.Text = "";
                    BatchIDFor.Text = "";
                    MessageBox.Show("Batch added");
                    connectionString.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddingCourse_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connectionString = new SqlConnection("Data Source=MUNEERNOTEBOOK;Initial Catalog=School_System;Integrated Security=True");
            try
            {
                connectionString.Open();
                SqlCommand cmd = new SqlCommand("insert into Courses(CourseName,CourseID,EmployeeID,BatchID) values('" + CourseNameFor.Text + "','" + CourseIDsFor.Text + "','" + EmpIDfor.Text + "','" + BatchIDofCourse.Text + "')", connectionString);
                if (CourseNameFor.Text == "" || CourseIDsFor.Text == "" || EmpIDfor.Text == "" || BatchIDofCourse.Text == "")
                {
                    MessageBox.Show("Please enter correct values in textboxes!!!");
                }
                else
                {
                    cmd.ExecuteNonQuery();
                    CourseNameFor.Text = "";
                    CourseIDsFor.Text = "";
                    EmpIDfor.Text = "";
                    BatchIDofCourse.Text = "";
                    MessageBox.Show("Course added");
                    connectionString.Close();
                }
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
