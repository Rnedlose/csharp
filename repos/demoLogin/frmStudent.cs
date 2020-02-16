using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace demoLogin
{
    public partial class frmStudent : Form
    {
        SqlConnection sqlConn = new SqlConnection(@"Data Source=database-college.database.windows.net;Initial Catalog=college-database;Persist Security Info=True;User ID=dbadmin;Password=R@dshed0784");
        private string userName;
        private int s_id;

        public frmStudent(int s_id, string userName)
        {
            this.userName = userName;
            this.s_id = s_id;
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int s_id;

                userName = userName.Substring(userName.IndexOf('.') + 1);

                sqlConn.Open();

                SqlCommand cmd = new SqlCommand("select s_id_num from student.student_records where last_name like '%"+ userName +"%'", sqlConn);

                s_id = ((int)cmd.ExecuteScalar());

                sqlConn.Close();
                frmCrsAvail objFrmCrsAvail = new frmCrsAvail(s_id, userName);
                this.Hide();
                objFrmCrsAvail.Show();
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                frmCurCrs objFrmEnrCrs = new frmCurCrs(s_id ,userName);
                this.Hide();
                objFrmEnrCrs.Show();
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd2 = new SqlCommand("select student_grade from course.course_records where s_id_num = '"+ s_id +"' and student_grade <> '"+null+"'", sqlConn);
                SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
                DataTable dtbl2 = new DataTable();
                sda2.Fill(dtbl2);

                if(dtbl2.Rows.Count == 0)
                {
                    MessageBox.Show("No grades input yet.  Try again soon");                    
                }
                else
                {
                    string grade;

                    float numGrds = 0;
                    float total = 0;
                    float gpa = 0;
                    
                    for (int i = 0; i < dtbl2.Rows.Count; i++)
                    {
                        grade = dtbl2.Rows[i]["student_grade"].ToString();
                        numGrds += 1;

                        if (grade == "a" || grade == "A") total += 4;
                        else if (grade == "b" || grade == "B") total += 3;
                        else if (grade == "c" || grade == "C") total += 2;
                        else if (grade == "d" || grade == "D") total += 1;
                        else total += 0;
                    }

                    gpa = total / numGrds;

                    MessageBox.Show("Your Current GPA is: " + gpa);

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
    }
}
