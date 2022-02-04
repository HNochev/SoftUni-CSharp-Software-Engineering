using Microsoft.Data.SqlClient;
using System;

namespace _01.InitialSetup
{
    class Program
    {
        const string SqlConnectionString = "Server=DESKTOP-QE96OKD\\SQLEXPRESS;Database=MinionsDB;Integrated Security=true";
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(SqlConnectionString);

            using (connection)
            {
                connection.Open();
             // Create Database
             //   string createDatabase = "CREATE DATABASEMinionsDB";
             //
             //   using (SqlCommand command = new SqlCommand(createDatabase, connection))
             //   {
             //       command.ExecuteNonQuery();
             //   }
             
             // Insert Tables
             //   string[] createTableStatements = //GetCreateTableStatements();
             //
             //   foreach (var query in createTableStatements)
             //   {
             //       ExecuteNonQuery(connection, query);
             //   }

            // Insert Data
                var insertStatements = GetInsertTableStatements();

                foreach (var query in insertStatements)
                {
                    ExecuteNonQuery(connection, query);
                }
            }
        }

        private static void ExecuteNonQuery(SqlConnection connection, string query)
        {
            using (var command = new SqlCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        private static string[] GetInsertTableStatements()
        {
            string[] result = new string[]
            {
                "INSERT INTO Countries([Name]) VALUES ('Bulgara'), ('USA'), ('Germany'), ('Russia'), ('China')","INSERT INTO Towns([Name], CountryCode) VALUES ('Haskovo', 1), ('Detroit', 2), ('Berlin', 3), ('Saint Peterburg', 4), ('Bejing', 5)","INSERT INTO Minions([Name], Age, TownId) VALUES ('Ivan', 34, 1), ('John', 23, 2), ('Heinz', 54, 3), ('Egor', 31, 4), ('Han', 28, 5), ('Donald', 63, 2), ('Dimitry', 21, 4), ('Georgi', 34, 1), ('Nataliya', 32, 4), ('Sam', 44, 2), ('Marshall', 46, 2)","INSERT INTO EvilnessFactors([Name]) VALUES ('super good'), ('good'), ('bad'), ('evil'), ('super evil')","INSERT INTO Villains([Name], EvilnessFactorId) VALUES ('Mr, A', 1), ('Mr. Nobody', 2), ('Mr. Bad', 3), ('Mr. Propper', 4), ('Mr. Thanos', 5)","INSERT INTO MinionsVillains(MinionId, VillainId) VALUES (1, 1), (2, 2), (3, 3), (4, 4), (5, 5), (6, 2), (7, 4), (8, 1), (9, 4), (10, 2), (11, 2)"
            };

            return result;
        }

        private static string[] GetCreateTableStatements()
        {
        string[] result = new string[]
        {
                "CREATE TABLE Countries(Id INT PRIMARY KEY IDENTITY,[Name] VARCHAR(50) NOT NULL)","CREATE TABLE Towns(Id INT PRIMARY KEY IDENTITY,[Name] VARCHAR(50) NOT NULL,CountryCode INT FOREIGN KEY REFERENCES Countries(Id) NOT NULL)","CREATE TABLE Minions(Id INT PRIMARY KEY IDENTITY,[Name] VARCHAR(50) NOT NULL,Age INT NOT NULL,TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL)","CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY IDENTITY,[Name] VARCHAR(50) NOT NULL)","CREATE TABLE Villains(Id INT PRIMARY KEY IDENTITY,[Name] VARCHAR(50) NOT NULL,EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id) NOT NULL)","CREATE TABLE MinionsVillains(MinionId INT FOREIGN KEY REFERENCES Minions(Id) NOT NULL,VillainId INT FOREIGN KEY REFERENCES Villains(Id) NOT NULL CONSTRAINT PK_MinionsVillains PRIMARY KEY(MinionId, VillainId))"
            };

            return result;
        }
    }
}
