using Microsoft.Data.SqlClient;
using System;
using System.Linq;

namespace _08._Increase_Minion_Age
{
    class StartUp
    {
        private const string connectionString = "Server = .; Database = MinionsDB; Integrated Security = true;";
        static void Main(string[] args)
        {
            using var dbCon = new SqlConnection(connectionString);
            dbCon.Open();

            int[] minionsIds = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            foreach (var id in minionsIds)
            {
                using var command = new SqlCommand(@"UPDATE Minions
                                    SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                                    WHERE Id = @Id", dbCon);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }

            using var getMinionsCommand = new SqlCommand("SELECT Name, Age FROM Minions", dbCon);
            using var reader = getMinionsCommand.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader["Name"]} {reader["Age"]}");
            }
        }
    }
}
