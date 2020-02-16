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
    public partial class frmAddRemStd : Form
    {
        SqlConnection sqlConn = new SqlConnection(@"Data Source=database-college.database.windows.net;Initial Catalog=college-database;Persist Security Info=True;User ID=dbadmin;Password=R@dshed0784");
        public frmAddRemStd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int s_id = Int32.Parse(textBox1.Text);
                string age = textBox2.Text;
                string fName = textBox3.Text;
                string lName = textBox4.Text;
                string addr = textBox5.Text;
                string year = textBox6.Text;

                sqlConn.Open();

                SqlCommand cmd = new SqlCommand("insert into student.student_records(s_id_num, age, first_name, last_name, addr, school_year)" +
                    " values ('" + s_id + "','" + age + "','" + fName + "','" + lName + "','" + addr + "','" + year + "')", sqlConn);
                cmd.ExecuteScalar();

                sqlConn.Close();

                frmAdmin objFrmAdmin = new frmAdmin();
                this.Hide();
                objFrmAdmin.Show();
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
                int s_id_del = Int32.Parse(textBox7.Text);
                sqlConn.Open();

                SqlCommand cmd2 = new SqlCommand("delete from student.student_records where s_id_num ='" + s_id_del + "'", sqlConn);
                cmd2.ExecuteScalar();

                sqlConn.Close();

                frmAdmin objFrmAdmin = new frmAdmin();
                this.Hide();
                objFrmAdmin.Show();
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
