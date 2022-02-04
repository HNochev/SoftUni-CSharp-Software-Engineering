using Microsoft.Data.SqlClient;
using System;
using System.Dynamic;

namespace _09.IncreaseAgeStoredProcedure
{
    class Program
    {
        const string SqlConnectionString = "Server=DESKTOP-QE96OKD\\SQLEXPRESS;Database=MinionsDB;Integrated Security=true";
        static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());

            using (var connection = new SqlConnection(SqlConnectionString))
            {
                connection.Open();

                CreateProcedure(connection);

                ExecuteProcedure(connection, id);

                string selectMinionById = @"SELECT Name, Age FROM Minions WHERE Id = @Id";
                using (var command = new SqlCommand(selectMinionById, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var dataReader = command.ExecuteReader())
                    {
                        while(dataReader.Read())
                        {
                            string minionName = (string)dataReader[0];
                            int minionAge = (int)dataReader[1];

                            Console.WriteLine($"{minionName} – {minionAge} years old");
                        }
                    }
                }
            }
        }

        private static void ExecuteProcedure(SqlConnection connection, int id)
        {
            string executeProcedure = @"EXEC usp_GetOlder @Id";

            using (var command = new SqlCommand(executeProcedure, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
        }

        private static void CreateProcedure(SqlConnection connection)
        {
            string procedure = @"CREATE OR ALTER PROC usp_GetOlder @id INT
                AS
                    UPDATE Minions
                       SET Age += 1
                     WHERE Id = @id";

            using (var command = new SqlCommand(procedure, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}
