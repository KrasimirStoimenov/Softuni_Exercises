using Microsoft.Data.SqlClient;
using System;

namespace _04._Add_Minion
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string connectionString = "Server = .; Database = MinionsDB; Integrated Security = True;";

            using var dbCon = new SqlConnection(connectionString);

            dbCon.Open();

            string[] minionInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var minionName = minionInfo[1];
            var minionAge = int.Parse(minionInfo[2]);
            var minionTown = minionInfo[3];
            var townId = GetTownId(dbCon, minionTown);

            if (townId == null)
            {
                AddTownToDb(dbCon, minionTown);
                townId = GetTownId(dbCon, minionTown);
            }

            string[] villainInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var villainName = villainInfo[1];
            var villainId = GetVillainId(dbCon, villainName);
            if (villainId == null)
            {
                AddVillainToDb(dbCon, villainName);
                villainId = GetVillainId(dbCon, villainName);
            }

            AddMinionToDb(dbCon, minionName, minionAge, townId);
            ConnectMinionToVillain(dbCon, minionName, villainId);

            Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");

        }

        private static void ConnectMinionToVillain(SqlConnection dbCon, string minionName, object villainId)
        {
            var minionId = GetMinionId(dbCon, minionName);
            using var connectMinionWithVillain = new SqlCommand("INSERT INTO MinionsVillains VALUES(@minionId,@villainId)", dbCon);
            connectMinionWithVillain.Parameters.AddWithValue("@minionId", minionId);
            connectMinionWithVillain.Parameters.AddWithValue("@villainId", villainId);
        }

        private static void AddMinionToDb(SqlConnection dbCon, string minionName, int minionAge, object townId)
        {
            using var sqlCommand = new SqlCommand("INSERT INTO Minions VALUES (@minionName,@age,@townId)", dbCon);
            sqlCommand.Parameters.AddWithValue("@minionName", minionName);
            sqlCommand.Parameters.AddWithValue("@age", minionAge);
            sqlCommand.Parameters.AddWithValue("@townId", townId); //check if works
            sqlCommand.ExecuteNonQuery();
        }

        private static object GetMinionId(SqlConnection dbCon, string minionName)
        {
            using var sqlCommand = new SqlCommand("SELECT Id FROM Minions WHERE [Name] = @minionName", dbCon);
            sqlCommand.Parameters.AddWithValue("@minionName", minionName);

            var minionId = sqlCommand.ExecuteScalar();

            return minionId;
        }

        private static void AddVillainToDb(SqlConnection dbCon, string villainName)
        {
            using var sqlCommand = new SqlCommand("INSERT INTO Villains VALUES (@villainName,4)", dbCon);
            sqlCommand.Parameters.AddWithValue("@villainName", villainName);
            sqlCommand.ExecuteNonQuery();
            Console.WriteLine($"Villain {villainName} was added to the database.");
        }

        private static object GetVillainId(SqlConnection dbCon, string villainName)
        {
            using var sqlCommand = new SqlCommand("SELECT Id FROM Villains WHERE [Name] = @villainName", dbCon);
            sqlCommand.Parameters.AddWithValue("@villainName", villainName);

            var villainId = sqlCommand.ExecuteScalar();

            return villainId;
        }

        private static void AddTownToDb(SqlConnection dbCon, string minionTown)
        {
            using var addTownToDb = new SqlCommand("INSERT INTO Towns VALUES (@townName,1)", dbCon);
            addTownToDb.Parameters.AddWithValue("@townName", minionTown);
            addTownToDb.ExecuteNonQuery();
            Console.WriteLine($"Town {minionTown} was added to the database.");
        }


        private static object GetTownId(SqlConnection dbCon, string minionTown)
        {
            using var sqlCommand = new SqlCommand("SELECT Id FROM Towns WHERE [Name] = @minionTown", dbCon);

            sqlCommand.Parameters.AddWithValue("@minionTown", minionTown);
            var townId = sqlCommand.ExecuteScalar();

            return townId;
        }
    }
}
