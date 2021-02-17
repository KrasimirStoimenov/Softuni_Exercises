using Microsoft.Data.SqlClient;
using System;

namespace _03._Minion_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server = .; Database = MinionsDB; Integrated Security = True;";
            using var dbCon = new SqlConnection(connectionString);

            dbCon.Open();

            int searchedId = int.Parse(Console.ReadLine());
            using var command = new SqlCommand("SELECT Name FROM Villains WHERE Id = @Id", dbCon);
            command.Parameters.AddWithValue("@Id", searchedId);

            var villainName = command.ExecuteScalar();
            if (villainName == null)
            {
                Console.WriteLine($"No villain with ID {searchedId} exists in the database.");
            }
            else
            {
                using var secondCommand = new SqlCommand(@"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) AS RowNum,                                              m.Name,m.Age
                                                            FROM MinionsVillains AS mv
                                                            JOIN Minions AS m ON mv.MinionId = m.Id
                                                            WHERE mv.VillainId = @Id
                                                            ORDER BY m.Name", dbCon);
                secondCommand.Parameters.AddWithValue("@Id", searchedId);

                using var reader = secondCommand.ExecuteReader();
                Console.WriteLine($"Villain: {villainName}");

                if (reader.Read())
                {
                    Console.WriteLine($"{reader["RowNum"]}. {reader["Name"]} {reader["Age"]}");

                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["RowNum"]}. {reader["Name"]} {reader["Age"]}");
                    }
                }
                else
                {
                    Console.WriteLine("(no minions)");
                }

            }

        }
    }
}
