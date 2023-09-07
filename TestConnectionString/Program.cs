using Microsoft.Data.SqlClient;
using System;
using System.Data.SqlClient;

class Program
{

    static void Main()
    {

        string connectionString = "Data Source=DESKTOP-C254UA2;Initial Catalog=E Commerce Company;Integrated Security=True; TrustServerCertificate=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("Connection successful!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}