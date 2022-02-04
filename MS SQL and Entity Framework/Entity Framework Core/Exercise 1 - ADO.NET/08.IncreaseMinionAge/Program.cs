using Microsoft.Data.SqlClient;
using System;
using System.Linq;

namespace _08.IncreaseMinionAge
{
    class Program
    {
        const string SqlConnectionString = "Server=DESKTOP-QE96OKD\\SQLEXPRESS;Database=MinionsDB;Integrated Security=true";
        static void Main(string[] args)
        {
            int[] minionId = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            
            using (var connection = new SqlConnection(SqlConnectionString))
            {
                connection.Open();

                foreach (var id in minionId)
                {
                    UpdateMinionAgeById(connection, id);
                }

                string selectAllMinions = @"SELECT Name, Age FROM Minions";

                using (var command = new SqlCommand(selectAllMinions, connection))
                {
                    using (var dataReader = command.ExecuteReader())
                    {
                        while(dataReader.Read())
                        {
                            Console.WriteLine($"{(string)dataReader["Name"]} {(int)dataReader["Age"]}");
                        }
                    }
                }
            }
        }

        private static void UpdateMinionAgeById(SqlConnection connection, int id)
        {
            string updateMinions = @" UPDATE Minions
   SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
 WHERE Id = @Id";

            using (var command = new SqlCommand(updateMinions, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
        }
    }
}
