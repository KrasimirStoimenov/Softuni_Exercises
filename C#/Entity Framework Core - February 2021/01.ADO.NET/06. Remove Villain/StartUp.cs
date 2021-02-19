using Microsoft.Data.SqlClient;
using System;

namespace _06._Remove_Villain
{
    class StartUp
    {
        private const string connectionString = "Server = .; Database = MinionsDB; Integrated Security = True;";

        static void Main(string[] args)
        {
            using var dbCon = new SqlConnection(connectionString);
            dbCon.Open();

            int villainId = int.Parse(Console.ReadLine());
            string villainName = GetVillainName(villainId, dbCon);

            if (villainName == null)
            {
                Console.WriteLine("No such villain was found.");
                return;
            }

            SqlTransaction sqlTransaction = dbCon.BeginTransaction();

            SqlCommand command = dbCon.CreateCommand();
            command.Transaction = sqlTransaction;
            command.Parameters.AddWithValue("@villainId", villainId);

            try
            {
                command.CommandText = @"DELETE FROM MinionsVillains WHERE VillainId = @villainId";
                var minionsReleased = command.ExecuteNonQuery();

                command.CommandText = "DELETE FROM Villains WHERE Id = @villainId";
                command.ExecuteNonQuery();

                sqlTransaction.Commit();
                Console.WriteLine($"{villainName} was deleted.");
                Console.WriteLine($"{minionsReleased} minions were released.");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                sqlTransaction.Rollback();
            }
        }

        private static string GetVillainName(int villainId, SqlConnection dbCon)
        {
            string getVillainNameQuery = "SELECT Name FROM Villains WHERE Id = @villainId";
            using var command = new SqlCommand(getVillainNameQuery, dbCon);
            command.Parameters.AddWithValue("@villainId", villainId);
            var name = command.ExecuteScalar();
            return name as string;
        }
    }
}
