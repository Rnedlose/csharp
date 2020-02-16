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
    public partial class frmLogin : Form
    {
        SqlConnection sqlConn = new SqlConnection(@"Data Source=database-college.database.windows.net;Initial Catalog=college-database;Persist Security Info=True;User ID=dbadmin;Password=R@dshed0784");

        public frmLogin()
        {
            InitializeComponent();
        }
        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            try
            {
                string userName = textUsername.Text;
                string passWord = textPassword.Text;

                SqlCommand cmd = new SqlCommand("select username,password from tbl_Login where username ='" + userName + "'and password ='" + passWord + "'", sqlConn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);

                if (dtbl.Rows.Count > 0)
                {
                    sqlConn.Open();

                    SqlCommand cmd2 = new SqlCommand("select login_type from tbl_Login where username ='" + userName + "' and password ='" + passWord + "'", sqlConn);

                    
                    // Get result
                    int result = ((int)cmd2.ExecuteScalar());

                    // Admin Dashboard
                    if (result == 1)
                    {
                        frmAdmin objFrmDash = new frmAdmin();
                        this.Hide();
                        objFrmDash.Show();
                    }
                    // Faculty Dashboard
                    else if (result == 2)
                    {
                        frmFaculty objFrmDash = new frmFaculty();
                        this.Hide();
                        objFrmDash.Show();
                    }
                    // Student Dashboard
                    else if (result == 3)
                    {
                        int s_id;

                        string uName = userName.Substring(userName.IndexOf('.') + 1);

                        SqlCommand cmd1 = new SqlCommand("select s_id_num from student.student_records where last_name like '%" + uName + "%'", sqlConn);

                        s_id = ((int)cmd1.ExecuteScalar());

                        frmStudent objFrmDash = new frmStudent(s_id, userName);
                        this.Hide();
                        objFrmDash.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Check your username or password.");
                    textUsername.Clear();
                    textPassword.Clear();
                }
                sqlConn.Close();
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
