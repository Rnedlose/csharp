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
using System.Text.RegularExpressions;
using System.IO;

namespace demoLogin
{
    public partial class frmCrtUsr : Form
    {
        SqlConnection sqlConn = new SqlConnection(@"Data Source=database-college.database.windows.net;Initial Catalog=college-database;Persist Security Info=True;User ID=dbadmin;Password=R@dshed0784");
        public frmCrtUsr()
        {
            InitializeComponent();
        }
        public class PasswordPolicy
        {
            private static int Minimum_Length = 8;
            private static int Upper_Case_length = 1;
            private static int Lower_Case_length = 1;
            private static int NonAlpha_length = 1;
            private static int Numeric_length = 1;

            public static bool IsValid(string Password)
            {
                if (Password.Length < Minimum_Length)
                    return false;
                if (UpperCaseCount(Password) < Upper_Case_length)
                    return false;
                if (LowerCaseCount(Password) < Lower_Case_length)
                    return false;
                if (NumericCount(Password) < Numeric_length)
                    return false;
                if (NonAlphaCount(Password) < NonAlpha_length)
                    return false;
                return true;            
            }

            private static int UpperCaseCount(string Password)
            {
                return Regex.Matches(Password, "[A-Z]").Count;
            }

            private static int LowerCaseCount(string Password)
            {
                return Regex.Matches(Password, "[a-z]").Count;
            }
            private static int NumericCount(string Password)
            {
                return Regex.Matches(Password, "[0-9]").Count;
            }
            private static int NonAlphaCount(string Password)
            {
                return Regex.Matches(Password, @"[^0-9a-zA-Z\._]").Count;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == textBox3.Text)
                {
                    if (PasswordPolicy.IsValid(textBox2.Text))
                    {
                        string passWord = textBox2.Text;
                        string userName = textBox1.Text;
                        string userType = textBox4.Text;

                        if (userType.Equals("admin", StringComparison.InvariantCultureIgnoreCase))
                        {
                            frmAuth objFrmAuth = new frmAuth(userName, passWord);
                            this.Hide();
                            objFrmAuth.Show();
                        }
                        else if (userType.Equals("faculty", StringComparison.InvariantCultureIgnoreCase))
                        {
                            sqlConn.Open();

                            SqlCommand cmd = new SqlCommand("insert into tbl_Login(username, password, login_type) values ('" + userName + "','" + passWord + "', 2)", sqlConn);
                            cmd.ExecuteScalar();

                            MessageBox.Show("User Created!!");

                            frmLogin objFrmLogin = new frmLogin();
                            this.Hide();
                            objFrmLogin.Show();

                            sqlConn.Close();
                        }
                        else if (userType.Equals("student", StringComparison.InvariantCultureIgnoreCase))
                        {
                            sqlConn.Open();

                            SqlCommand cmd = new SqlCommand(@"insert into tbl_Login(username, password, login_type) values ('" + userName + "','" + passWord + "', 3)", sqlConn);
                            cmd.ExecuteScalar();

                            MessageBox.Show("User Created!!");

                            frmLogin objFrmLogin = new frmLogin();
                            this.Hide();
                            objFrmLogin.Show();

                            sqlConn.Close();
                        }
                        else
                        {
                            MessageBox.Show("Invalid User Type");
                            textBox1.Clear();
                            textBox2.Clear();
                            textBox3.Clear();
                            textBox4.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Password doesn't meet requirements.");
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Passwords must match.");
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
    }
}
