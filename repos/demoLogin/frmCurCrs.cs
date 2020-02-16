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
using System.Collections;

namespace demoLogin
{
    public partial class frmCurCrs : Form
    {
        SqlConnection sqlConn = new SqlConnection(@"Data Source=database-college.database.windows.net;Initial Catalog=college-database;Persist Security Info=True;User ID=dbadmin;Password=R@dshed0784");
        private int s_id;
        private string userName;
        public frmCurCrs(int s_id, string userName)
        {
            this.s_id = s_id;
            this.userName = userName;
            InitializeComponent();
            FillData();
        }

        private void FillData()
        {
            sqlConn.Open();

            SqlCommand cmd = new SqlCommand("select c_id_num from course.course_records where s_id_num = '"+ s_id +"' and current_course = '"+ 1 +"'", sqlConn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);

            if (dtbl.Rows.Count == 0)
            {
                MessageBox.Show("You have not enrolled in any courses as of yet.");

                this.Hide();
                frmStudent objFrmStudent = new frmStudent(s_id, userName);
                objFrmStudent.Show();
            }
            else
            {
                for (int i = 0; i < dtbl.Rows.Count; i++) 
                {
                    int result = Convert.ToInt32(dtbl.Rows[i]["c_id_num"]);
                    SqlCommand cmd2 = new SqlCommand("select course_name from course.course_offerings where c_id_num = '"+ result +"'", sqlConn);

                    string course = cmd2.ExecuteScalar().ToString();
                    listView1.Items.Add(course);
                }

            }
        }
        private void button4_Click(object sender, EventArgs e)
        {           
            try
            {
                this.Hide();
                frmStudent objFrmStudent = new frmStudent(s_id, userName);
                objFrmStudent.Show();
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
