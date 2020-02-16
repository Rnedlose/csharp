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
    public partial class frmAuth : Form
    {
        SqlConnection sqlConn = new SqlConnection(@"Data Source=database-college.database.windows.net;Initial Catalog=college-database;Persist Security Info=True;User ID=dbadmin;Password=R@dshed0784");
        private string userName;
        private string passWord;

        public frmAuth(string text1, string text2)
        {
            this.userName = text1;
            this.passWord = text2;
            InitializeComponent();         
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select username,password from tbl_Login where username='" + textUsername.Text + "'and password='" + textPassword.Text + "'", sqlConn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);

                if (dtbl.Rows.Count > 0)
                {

                    sqlConn.Open();

                    SqlCommand cmd2 = new SqlCommand("select login_type from tbl_Login where username='" + textUsername.Text + "' and password='" + textPassword.Text + "'", sqlConn);

                    // Get result
                    int result = ((int)cmd2.ExecuteScalar());

                    // Admin Dashboard
                    if (result == 1)
                    {
                        SqlCommand cmd3 = new SqlCommand("insert into tbl_Login(username, password, login_type) values ('" + this.userName + "','" + this.passWord + "', 1)", sqlConn);
                        cmd3.ExecuteScalar();

                        MessageBox.Show("User Created!!");

                        frmLogin objFrmLogin = new frmLogin();
                        this.Hide();
                        objFrmLogin.Show();
                    }
                    else
                    {
                        MessageBox.Show("You need Admin authorization in order to create a new Admin User.");
                    }

                }
                else
                {
                    MessageBox.Show("Check your username or password.");
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
                this.Close();
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