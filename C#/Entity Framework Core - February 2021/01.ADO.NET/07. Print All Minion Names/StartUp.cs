using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace _07._Print_All_Minion_Names
{
    class StartUp
    {
        private const string connectionString = "Server = .;Database = MinionsDB; Integrated Security = true;";
        static void Main(string[] args)
        {
            using var dbCon = new SqlConnection(connectionString);
            dbCon.Open();

            string getMinionsQuery = "SELECT Name FROM Minions";

            using var command = new SqlCommand(getMinionsQuery, dbCon);
            using var reader = command.ExecuteReader();
            List<string> minions = new List<string>();

            while (reader.Read())
            {
                minions.Add(reader["Name"].ToString());
            }

            for (int i = 0; i < minions.Count/2; i++)
            {
                Console.WriteLine(minions[i]);
                Console.WriteLine(minions[minions.Count-i-1]);
            }

            if(minions.Count %2 != 0)
            {
                Console.WriteLine(minions[minions.Count/2]);
            }
        }
    }
}
