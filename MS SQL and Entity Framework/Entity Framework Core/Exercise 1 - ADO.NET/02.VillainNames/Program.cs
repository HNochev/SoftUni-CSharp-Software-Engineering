using Microsoft.Data.SqlClient;
using System;

namespace _02.VillainNames
{
    class Program
    {
        const string SqlConnectionString = "Server=DESKTOP-QE96OKD\\SQLEXPRESS;Database=MinionsDB;Integrated Security=true";
        static void Main(string[] args)
        {
            using (var connection = new SqlConnection(SqlConnectionString))
            {
                connection.Open();

                var selectQuery = @"  SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                         FROM Villains AS v 
                                         JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                                         GROUP BY v.Id, v.Name 
                                            HAVING COUNT(mv.VillainId) > 2 
                                        ORDER BY COUNT(mv.VillainId)";

                using (var command = new SqlCommand(selectQuery, connection))
                {
                    using (var dataReader = command.ExecuteReader())
                    {
                        while(dataReader.Read())
                        {
                            Console.WriteLine($"{dataReader[0]} - {dataReader[1]}");
                        }
                    }
                }
            }
        }
    }
}
