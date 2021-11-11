using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace _08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestAndPassword = new Dictionary<string, string>();

            Dictionary<string, Dictionary<string, int>> users = new Dictionary<string, Dictionary<string, int>>();

            string[] input1 = Console.ReadLine()
                .Split(":", StringSplitOptions.RemoveEmptyEntries);

            while (input1[0] != "end of contests")
            {
                if (!contestAndPassword.ContainsKey(input1[0]))
                {
                    contestAndPassword.Add(input1[0], input1[1]);
                }

                input1 = Console.ReadLine()
                .Split(":", StringSplitOptions.RemoveEmptyEntries);
            }

            string[] input2 = Console.ReadLine()
                .Split("=>", StringSplitOptions.RemoveEmptyEntries);
            while (input2[0] != "end of submissions")
            {
                string contest = input2[0];
                string password = input2[1];
                string username = input2[2];
                int points = int.Parse(input2[3]);

                if (contestAndPassword.ContainsKey(contest) &&
                    contestAndPassword[contest] == password &&
                    !users.ContainsKey(username))
                {
                    users.Add(username, new Dictionary<string, int>());
                }
                if (users.ContainsKey(username))
                {
                    if (!users[username].ContainsKey(contest))
                    {
                        users[username].Add(contest, points);
                    }
                    else
                    {
                        if (users[username][contest] < points)
                        {
                            users[username][contest] = points;
                        }
                    }
                }

                input2 = Console.ReadLine()
                .Split("=>", StringSplitOptions.RemoveEmptyEntries);
            }

            string bestName = "";
            int bestPoints = 0;

            foreach (var user in users)
            {
                int currPoints = 0;
                foreach (var contests in user.Value)
                {
                    currPoints = currPoints + contests.Value;
                }
                if (currPoints > bestPoints)
                {
                    bestPoints = currPoints;
                    bestName = user.Key;
                }
            }


            Console.WriteLine($"Best candidate is {bestName} with total {bestPoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var user in users.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{user.Key}");
                foreach (var contest in user.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
