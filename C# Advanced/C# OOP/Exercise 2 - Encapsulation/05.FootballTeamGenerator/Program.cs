using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FootballTeamGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Team> teamsByName = new Dictionary<string, Team>();

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "END")
                {
                    break;
                }

                try
                {

                    if (input[0] == "Team")
                    {
                        string teamName = input[1];

                        Team team = new Team(teamName);

                        teamsByName.Add(teamName, team);
                    }
                    else if (input[0] == "Add")
                    {
                        string teamName = input[1];

                        if (!teamsByName.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            continue;
                        }

                        string playerName = input[2];
                        double endurance = double.Parse(input[3]);
                        double sprint = double.Parse(input[4]);
                        double dribble = double.Parse(input[5]);
                        double passing = double.Parse(input[6]);
                        double shooting = double.Parse(input[7]);

                        Team team = teamsByName[teamName];
                        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

                        team.AddPlayer(player);
                    }
                    else if (input[0] == "Remove")
                    {
                        string teamName = input[1];
                        string playerName = input[2];

                        Team team = teamsByName[teamName];

                        team.RemovePlayer(playerName);
                    }
                    else if (input[0] == "Rating")
                    {
                        string teamName = input[1];

                        if (!teamsByName.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            continue;
                        }
                        else
                        {
                            Team team = teamsByName[teamName];

                            Console.WriteLine($"{teamName} - {team.AverageRating}");
                        }
                    }
                }
                catch (Exception ex)
                    when (ex is ArgumentException || ex is InvalidOperationException)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}
