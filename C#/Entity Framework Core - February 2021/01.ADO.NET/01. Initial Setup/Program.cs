using System;
using Microsoft.Data.SqlClient;
namespace ADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
           SqlConnection connection = new SqlConnection("Server = .; Database = MinionsDB; Integrated Security = True;");
            connection.Open();
            connection.Close();
        }
    }
}
