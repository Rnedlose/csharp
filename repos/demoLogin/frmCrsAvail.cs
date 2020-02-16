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
    public partial class frmCrsAvail : Form
    {
        private int s_id;
        private string userName;

        SqlConnection sqlConn = new SqlConnection(@"Data Source=database-college.database.windows.net;Initial Catalog=college-database;Persist Security Info=True;User ID=dbadmin;Password=R@dshed0784");


        public frmCrsAvail(int s_id, string userName)
        {
            this.userName = userName;
            this.s_id = s_id;
            InitializeComponent();

            FillData();
        }

        private void FillData()
        {
            try
            {
                ArrayList arrOfCourseIDs = new ArrayList();
                ArrayList arrOfCourseNames = new ArrayList();
                ArrayList c_ids_taken = new ArrayList();
                sqlConn.Open();

                SqlCommand cmd = new SqlCommand("select * from course.course_records where s_id_num = '"+ s_id +"'", sqlConn);
                SqlCommand cmd2 = new SqlCommand("select c_id_num, course_name from course.course_offerings where course_requirements = '" + 0 + "'", sqlConn);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);

                SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
                DataTable dtbl2 = new DataTable();
                sda2.Fill(dtbl2);

                if (dtbl.Rows.Count > 0)
                {
                    for (int i = 0; i < dtbl.Rows.Count; i++)
                    {
                        c_ids_taken.Add(Convert.ToInt32(dtbl.Rows[i]["c_id_num"]));
                    }

                    for (int h = 0; h < dtbl2.Rows.Count; h++)
                    {
                        arrOfCourseIDs.Add(Convert.ToInt32(dtbl2.Rows[h]["c_id_num"]));
                        arrOfCourseNames.Add(dtbl2.Rows[h]["course_name"].ToString());
                    }

                    for (int g = 0; g < c_ids_taken.Count; g++)
                    {
                        for (int m = 0; m < arrOfCourseNames.Count; m++)
                        {
                            if (arrOfCourseIDs[m].Equals(c_ids_taken[g]))
                            {
                                arrOfCourseIDs.RemoveAt(m);
                                arrOfCourseNames.RemoveAt(m);
                            }
                        }
                    }

                    for (int n = 0; n < arrOfCourseNames.Count; n++)
                    {
                        listView1.Items.Add((string)arrOfCourseNames[n]);
                    }
                    
                    for (int j = 0; j < c_ids_taken.Count; j++)
                    {
                        SqlCommand cmd3 = new SqlCommand("select course_name from course.course_offerings where course_requirements = '" + c_ids_taken[j] + "' ", sqlConn);

                        string cName = (string)cmd3.ExecuteScalar();

                        listView1.Items.Add(cName);
                    }
;
                }
                else
                {
                    SqlCommand cmd4 = new SqlCommand("select course_name from course.course_offerings where course_requirements = '" + 0 + "'", sqlConn);
                    SqlDataAdapter sda3 = new SqlDataAdapter(cmd);
                    DataTable dtbl3 = new DataTable();
                    sda3.Fill(dtbl3);

                    for (int x = 0; x < dtbl2.Rows.Count; x++)
                    {
                        arrOfCourseNames.Add(dtbl2.Rows[x]["course_name"].ToString());
                        listView1.Items.Add((string)arrOfCourseNames[x]);
                    }
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cId;
            int fId;
            
            if (this.listView1.SelectedItems.Count == 0)
                return;

            string selCourse1 = this.listView1.SelectedItems[0].Text;

            sqlConn.Open();

            SqlCommand cmd5 = new SqlCommand("select c_id_num, f_id_num from course.course_offerings where course_name = '" + selCourse1 + "' ", sqlConn);
            SqlDataAdapter sda4 = new SqlDataAdapter(cmd5);
            DataTable dtbl3 = new DataTable();
            sda4.Fill(dtbl3);

            SqlCommand cmd6 = new SqlCommand("select current_course from course.course_records where current_course = '" + 1 +"' and s_id_num = '"+ s_id +"'", sqlConn);
            SqlDataAdapter sda5 = new SqlDataAdapter(cmd6);
            DataTable dtbl4 = new DataTable();
            sda5.Fill(dtbl4);

            if(dtbl4.Rows.Count > 2)
            {
                MessageBox.Show("You can only take 3 courses at one time.");
            }
            else
            {
                for (int i = 0; i < dtbl3.Rows.Count; i++)
                {
                    cId = Convert.ToInt32(dtbl3.Rows[i]["c_id_num"]);
                    fId = Convert.ToInt32(dtbl3.Rows[i]["f_id_num"]);

                    SqlCommand cmd7 = new SqlCommand("insert into course.course_records(c_id_num, f_id_num, s_id_num, student_grade, current_course, student_finished_course)" +
                                    "values ('" + cId + "', '" + fId + "', '" + s_id + "', '" + "a" + "', '" + 1 + "', '" + 0 + "')", sqlConn);

                    cmd7.ExecuteScalar();
                }
            }

            sqlConn.Close();

            this.Hide();
            frmStudent objFrmStudent = new frmStudent(s_id, userName);
            objFrmStudent.Show();

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
