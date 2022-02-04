using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace _07.PrintAllMinionNames
{
    class Program
    {
        const string SqlConnectionString = "Server=DESKTOP-QE96OKD\\SQLEXPRESS;Database=MinionsDB;Integrated Security=true";
        static void Main(string[] args)
        {
            using (var connection = new SqlConnection(SqlConnectionString))
            {
                connection.Open();

                List<string> minionNames = GetAllMinionNames(connection);

                Console.WriteLine($"Minions are {minionNames.Count} total.");

                for (int i = 0; i < minionNames.Count / 2; i++)
                {
                    Console.WriteLine(minionNames[i]);
                    Console.WriteLine(minionNames[minionNames.Count - i - 1]);
                }

                if(minionNames.Count % 2 != 0)
                {
                    Console.WriteLine(minionNames[minionNames.Count / 2]);
                }
            }
        }

        private static List<string> GetAllMinionNames(SqlConnection connection)
        {
            List<string> minionNames = new List<string>();

            string selectNames = "SELECT Name FROM Minions";

            using (var command = new SqlCommand(selectNames, connection))
            {
                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        minionNames.Add(dataReader[0].ToString());
                    }
                }
            }

            return minionNames;
        }
    }
}
