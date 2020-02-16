using System;
using System.Text;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace SqlServerSample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Set the Connection String to the DB

                String ConnString = "Server=tcp:database-college.database.windows.net,1433;Database=college-database;Uid=dbadmin;Pwd=R@dshed0784";
                
                // Connect to SQL
                Console.Write("Connecting to SQL Server ... ");
                using (SqlConnection connection = new SqlConnection(ConnString))
                {
                    String sql1 = "INSERT INTO student.student_records (s_id_num, age, first_name, last_name, addr, gpa, school_year) VALUES (2, '20', 'The', 'Science Guy', '54321 Test Lane', 4, '4');";
                    String sql2 = "SELECT * FROM student.student_records;";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql1, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("Successfully Wrote to DB.");
                    }
                    using (SqlCommand command2 = new SqlCommand(sql2, connection))
                    {
                        command2.ExecuteNonQuery();
                        
                        using (SqlDataReader reader = command2.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5), reader.GetString(6));
                            }
                        }

                        Console.WriteLine("Successfully Read from DB.");
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("All done. Press any key to finish...");
            Console.ReadKey(true);
        }
    }
}
