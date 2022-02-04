using Microsoft.Data.SqlClient;
using System;

namespace _06.RemoveVillain
{
    class Program
    {
        const string SqlConnectionString = "Server=DESKTOP-QE96OKD\\SQLEXPRESS;Database=MinionsDB;Integrated Security=true";
        static void Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());

            using(var connection = new SqlConnection(SqlConnectionString))
            {
                connection.Open();

                string villainName = GetVillainNameById(connection, villainId);

                if(villainName == null)
                {
                    Console.WriteLine("No such villain was found.");
                    return;
                }

                var releasedMinions = GetReleasedMinions(connection, villainId);

                DeleteVillainById(connection, villainId);

                Console.WriteLine($"{villainName} was deleted.");
                Console.WriteLine($"{releasedMinions} minions were released.");
            }
        }

        private static void DeleteVillainById(SqlConnection connection, int villainId)
        {
            string deleteVillain = @"DELETE FROM Villains
      WHERE Id = @villainId";

            using (var command = new SqlCommand(deleteVillain, connection))
            {
                command.Parameters.AddWithValue("@villainId", villainId);

                command.ExecuteNonQuery();
            }
        }

        private static object GetReleasedMinions(SqlConnection connection, int villainId)
        {
            string deleteFromMappingTable = @"DELETE FROM MinionsVillains 
      WHERE VillainId = @villainId";

            using (var command = new SqlCommand(deleteFromMappingTable, connection))
            {
                command.Parameters.AddWithValue("@villainId", villainId);

                return command.ExecuteNonQuery();
            }
        }

        private static string GetVillainNameById(SqlConnection connection, int villainId)
        {
            string selectVillan = @"SELECT Name FROM Villains WHERE Id = @villainId";

            using (var command = new SqlCommand(selectVillan, connection))
            {
                command.Parameters.AddWithValue("@villainId", villainId);

                return (string)command.ExecuteScalar();
            }
        }
    }
}
