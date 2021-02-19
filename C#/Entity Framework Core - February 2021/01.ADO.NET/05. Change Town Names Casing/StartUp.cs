using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace _05._Change_Town_Names_Casing
{
    class StartUp
    {
        private const string connectionString = "Server = .; Database = MinionsDB; Integrated Security = True;";
        static void Main(string[] args)
        {
            using var dbCon = new SqlConnection(connectionString);

            dbCon.Open();

            string inputCountry = Console.ReadLine();

            string updateTownsQuery = @"UPDATE Towns
                            SET [Name] = UPPER([Name])
                            WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.[Name] = @countryName)";
            using var updateTownsCommand = new SqlCommand(updateTownsQuery, dbCon);
            updateTownsCommand.Parameters.AddWithValue("@countryName", inputCountry);

            var rowsAffected = updateTownsCommand.ExecuteNonQuery();

            if (rowsAffected == 0)
            {
                Console.WriteLine("No town names were affected.");
            }
            else
            {
                Console.WriteLine($"{rowsAffected} town names were affected.");
                string selectAffectedTownsQuerry = @"SELECT t.Name
                                                     FROM Towns as t
                                                     JOIN Countries AS c ON c.Id = t.CountryCode
                                                     WHERE c.Name = @countryName";

                using var townsCommand = new SqlCommand(selectAffectedTownsQuerry, dbCon);
                townsCommand.Parameters.AddWithValue("@countryName", inputCountry);

                using var reader = townsCommand.ExecuteReader();
                List<string> towns = new List<string>();
                while (reader.Read())
                {
                    var town = reader[0].ToString();
                    towns.Add(town);
                }
                Console.WriteLine($"[{string.Join(", ", towns)}]");
            }

        }
    }
}
