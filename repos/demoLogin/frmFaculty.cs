using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace demoLogin
{
    public partial class frmFaculty : Form
    {
        SqlConnection sqlConn = new SqlConnection(@"Data Source=database-college.database.windows.net;Initial Catalog=college-database;Persist Security Info=True;User ID=dbadmin;Password=R@dshed0784");
        private int c_id;
        private int s_id;
        public frmFaculty()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length < 1 || textBox2.Text.Length < 1 || textBox3.Text.Length < 1)
                {
                    MessageBox.Show("Please fill in every field");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                }
                else
                {
                    this.c_id = Int32.Parse(textBox1.Text);
                    this.s_id = Int32.Parse(textBox2.Text);
                    string grade = textBox3.Text;

                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand("select f_id_num from course.course_offerings where c_id_num = '" + c_id + "'", sqlConn);
                    int f_id = (int)cmd.ExecuteScalar();

                    SqlCommand cmd2 = new SqlCommand("select c_id_num, f_id_num, s_id_num from course.course_records where c_id_num = '" + c_id + "' and f_id_num = '" 
                                                    + f_id + "' and s_id_num = '" + s_id + "'", sqlConn);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd2);
                    DataTable dtbl = new DataTable();
                    sda.Fill(dtbl);

                    if (dtbl.Rows.Count > 0)
                    {
                        if (textBox4.Text.Equals("yes", StringComparison.InvariantCultureIgnoreCase) || textBox4.Text.Equals("y", StringComparison.InvariantCultureIgnoreCase))
                        {
                            SqlCommand cmd4 = new SqlCommand("update course.course_records set student_grade = '" + grade + "' ,current_course = '"+ 0 +"'" +
                                                            ",student_finished_course = '" + 1 + "' where c_id_num = '" + this.c_id + "' and f_id_num = '" + f_id + "' " +
                                                            "and s_id_num = '" + this.s_id + "'", sqlConn);
                            cmd4.ExecuteScalar();
                        }
                        else
                        {
                            SqlCommand cmd3 = new SqlCommand("update course.course_records set student_grade = '" + grade + "'" +
                                                            "where c_id_num = '" + this.c_id + "' and f_id_num = '" + f_id + "' and s_id_num = '" + this.s_id + "'", sqlConn);
                            cmd3.ExecuteScalar();
                        }

                    }

                    else
                    {
                        SqlCommand cmd5 = new SqlCommand("insert into course.course_records (c_id_num, f_id_num, s_id_num, student_grade, current_course, student_finished_course) " +
                                                        "values ('" + c_id + "','" + f_id + "','" + s_id + "','" + grade +"', '"+ 1 +"', '"+ 0 +"')", sqlConn);
                        cmd5.ExecuteScalar();
                    }

                    sqlConn.Close();
                    MessageBox.Show("Grade Updated!!");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred but your application did not crash.  Please contact a system admin if this continues.");
                string filePath = @"C:\Users\Error.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("-----------------------------------------------------------------------------");
                    writer.WriteLine("Date : " + DateTime.Now.ToString());
                    writer.WriteLine();

                    while (ex != null)
                    {
                        writer.WriteLine(ex.GetType().FullName);
                        writer.WriteLine("Message : " + ex.Message);
                        writer.WriteLine("StackTrace : " + ex.StackTrace);
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred but your application did not crash.  Please contact a system admin if this continues.");
                string filePath = @"C:\Users\Error.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("-----------------------------------------------------------------------------");
                    writer.WriteLine("Date : " + DateTime.Now.ToString());
                    writer.WriteLine();

                    while (ex != null)
                    {
                        writer.WriteLine(ex.GetType().FullName);
                        writer.WriteLine("Message : " + ex.Message);
                        writer.WriteLine("StackTrace : " + ex.StackTrace);
                    }
                }
            }
        }


    }
}
