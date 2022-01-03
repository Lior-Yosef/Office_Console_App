using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Office_Console_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> EmployeeList = new List<Employee>();

            string connctionString = "Data Source=LAPTOP-OT5IVM7S;Initial Catalog=OfficeDB;Integrated Security=True;Pooling=False";


            //Employee mission

            ShowEmployee(connctionString);
            //AddEmployee(connctionString);
            //EditEmployee(connctionString);
            //DeleteEmployee(connctionString,int.Parse(Console.ReadLine()) );
        }

        static void ShowEmployee(string connctionString)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connctionString))
                {
                    conn.Open();
                    string query = @"SELECT * FROM Employee";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    var dataFromDb = cmd.ExecuteReader();
                    //מחזיר את כל הנתונים מהשאילתא

                    if (dataFromDb.HasRows)
                    {
                        while (dataFromDb.Read())
                        {
                            Console.WriteLine(dataFromDb.GetInt32(0));
                            Console.WriteLine(dataFromDb.GetString(1));
                            Console.WriteLine(dataFromDb.GetDateTime(2));
                            Console.WriteLine(dataFromDb.GetString(3));
                            Console.WriteLine(dataFromDb.GetInt32(4));

                        }
                    }
                    else
                    {
                        Console.WriteLine("no rows in table");
                    }
                }
            }
            catch (SqlException)
            {
                Console.WriteLine("err data");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void AddEmployee(string connctionString)
        {
            Console.WriteLine("Enter Your Full Name");
            string FullName = Console.ReadLine();

            Console.WriteLine("Enter Your born year");
            string born = Console.ReadLine();

            Console.WriteLine("Enter Your email");
            string email = Console.ReadLine();

            Console.WriteLine("Enter your salary");
            string salary = Console.ReadLine();

            try
            {
                using (SqlConnection conn = new SqlConnection(connctionString))
                {
                    conn.Open();

                    string query = $@"INSERT INTO Employee(FullName,Born,Email,Pay)
                    VALUES('{FullName}','{born}','{email}','{salary}')";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    
                    int rowsEffected = cmd.ExecuteNonQuery();
                    //מחזיר את מספר השורות שהושפעו

                    Console.WriteLine(rowsEffected);
                    conn.Close();
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
         






        }

        static void EditEmployee(string connctionString)
        {
            Console.WriteLine("Enter Your Id number");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Your Full Name");
            string FullName = Console.ReadLine();

            Console.WriteLine("Enter Your born year");
            string born = Console.ReadLine();

            Console.WriteLine("Enter Your email");
            string email = Console.ReadLine();

            Console.WriteLine("Enter your salary");
            string salary = Console.ReadLine();

            try
            {
                using (SqlConnection conn = new SqlConnection(connctionString))
                {
                    conn.Open();

                    string query = $@"UPDATE Employee
                                    SET FullName = '{FullName}', Born='{born}', 
                                        Email ='{email}', Pay='{salary}' 
                                        WHERE Id={id} ";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    int rowsEffected = cmd.ExecuteNonQuery();
                    Console.WriteLine(rowsEffected);

                    conn.Close();


                }


            }
            

            catch (SqlException sqlError)
            {

                Console.WriteLine(sqlError.Message);
            }
            catch (Exception error)
            {

                Console.WriteLine(error.Message);
            }

        }

        static void DeleteEmployee(string connctionString, int id)
        {
            //Console.WriteLine("enter your id number");
            //int id = int.Parse(Console.ReadLine());
            try
            {
                using (SqlConnection conn = new SqlConnection(connctionString))
                {
                    conn.Open();

                    string query = $@"DELETE FROM Employee WHERE Id = {id}";
                                   

                    SqlCommand cmd = new SqlCommand(query, conn);
                    int rowsEffected = cmd.ExecuteNonQuery();
                    Console.WriteLine(rowsEffected);
                    conn.Close();


                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
