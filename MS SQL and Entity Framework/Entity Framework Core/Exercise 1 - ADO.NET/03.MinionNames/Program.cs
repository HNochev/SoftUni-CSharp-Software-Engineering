using Microsoft.Data.SqlClient;
using System;

namespace _03.MinionNames
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

                var selectVillains = @"SELECT Name FROM Villains WHERE Id = @Id";

                using (var command = new SqlCommand(selectVillains, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    var villainName = (string)command.ExecuteScalar();

                    if (villainName == null)
                    {
                        Console.WriteLine($"No villain with ID {id} exists in the database.");
                        return;
                    }

                    Console.WriteLine($"Villain: {villainName}");
                }

                var selectMinions = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";

                using (var command = new SqlCommand(selectMinions, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var dataReader = command.ExecuteReader())
                    {
                        if (!dataReader.HasRows)
                        {
                            Console.WriteLine("(no minions)");
                            return;
                        }

                        while (dataReader.Read())
                        {
                            string rowNumber = dataReader[0].ToString();
                            string name = (string)dataReader[1];
                            int age = (int)dataReader[2];

                            Console.WriteLine($"{rowNumber}. {name} {age}");
                        }
                    }
                }
            }
        }
    }
}
