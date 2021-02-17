using Microsoft.Data.SqlClient;
using System;

namespace _02._Villain_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server = .; Database = MinionsDB; Integrated Security = True;";
            using var dbCon = new SqlConnection(connectionString);

            dbCon.Open();

            using var query = new SqlCommand(@"SELECT v.[Name], COUNT(mv.MinionId) AS MinionsCount
                                       FROM Villains v
                                       JOIN MinionsVillains mv ON mv.VillainId = v.Id
                                       GROUP BY v.[Name]
                                       HAVING COUNT(mv.MinionId) > 3
                                       ORDER BY MinionsCount", dbCon);

            using var reader = query.ExecuteReader();

                while (reader.Read())
            {
                string villainName = reader["Name"] as string;
                int? minionsCount = reader["MinionsCount"] as int?;

                Console.WriteLine($"{villainName} - {minionsCount}");
            }
        }

    }
}
