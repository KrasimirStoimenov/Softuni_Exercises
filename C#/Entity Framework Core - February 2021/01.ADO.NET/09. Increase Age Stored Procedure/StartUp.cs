using Microsoft.Data.SqlClient;
using System;

namespace _09._Increase_Age_Stored_Procedure
{
    class StartUp
    {
        private const string connectionString = "Server = .; Database = MinionsDB; Integrated Security = true;";
        static void Main(string[] args)
        {
            using var dbCon = new SqlConnection(connectionString);
            dbCon.Open();

            int minionId = int.Parse(Console.ReadLine());

            string procedure = "usp_GetOlder";
            using var command = new SqlCommand(procedure, dbCon);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@minionId", minionId);
            command.ExecuteNonQuery();

            using var retrieveMinion = new SqlCommand("SELECT Name, Age FROM Minions WHERE Id = @Id",dbCon);
            retrieveMinion.Parameters.AddWithValue("@Id", minionId);
            using var reader = retrieveMinion.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader["Name"]} - {reader["Age"]} years old");
            }


        }
    }
}
