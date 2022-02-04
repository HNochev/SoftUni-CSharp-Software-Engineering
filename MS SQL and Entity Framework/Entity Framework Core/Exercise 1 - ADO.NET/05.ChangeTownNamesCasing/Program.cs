using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace _05.ChangeTownNamesCasing
{
    class Program
    {
        const string SqlConnectionString = "Server=DESKTOP-QE96OKD\\SQLEXPRESS;Database=MinionsDB;Integrated Security=true";
        static void Main(string[] args)
        {
            string countryName = Console.ReadLine();

            using (var connection = new SqlConnection(SqlConnectionString))
            {
                connection.Open();

                var rowsAffected = GetAffectedRows(connection, countryName);

                if(rowsAffected <= 0)
                {
                    Console.WriteLine("No town names were affected.");
                    return;
                }

                Console.WriteLine($"{rowsAffected} town names were affected.");

                List<string> townNames = GetTownsByName(connection, countryName);

                Console.WriteLine($"[{string.Join(", ", townNames)}]");
            }
        }

        private static List<string> GetTownsByName(SqlConnection connection, string countryName)
        {
            var selectTowns = @" SELECT t.Name 
   FROM Towns as t
   JOIN Countries AS c ON c.Id = t.CountryCode
  WHERE c.Name = @countryName";

            List<string> towns = new List<string>();

            using (var command = new SqlCommand(selectTowns, connection))
            {
                command.Parameters.AddWithValue("@countryName", countryName);

                using (var dataReader = command.ExecuteReader())
                {
                    while(dataReader.Read())
                    {
                        towns.Add(dataReader[0].ToString());
                    }
                }
            }

            return towns;
        }

        private static int GetAffectedRows(SqlConnection connection, string countryName)
        {
            string updateQuery = @"UPDATE Towns
   SET Name = UPPER(Name)
 WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

            using (var command = new SqlCommand(updateQuery, connection))
            {
                command.Parameters.AddWithValue("@countryName", countryName);

                return command.ExecuteNonQuery();
            }
        }
    }
}
