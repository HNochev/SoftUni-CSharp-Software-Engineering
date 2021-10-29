using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace Second
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> friends = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();

            List<string> blacklistedFriends = new List<string>();
            List<string> lostNames = new List<string>();

            while (input != "Report")
            {
                string[] command = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                switch (command[0])
                {
                    case "Blacklist":
                        {
                            if (friends.Contains(command[1]))
                            {
                                int index = friends.IndexOf(command[1]);
                                blacklistedFriends.Add(command[1]);
                                friends[index] = "Blacklisted";
                                Console.WriteLine($"{command[1]} was blacklisted.");
                            }
                            else
                            {
                                Console.WriteLine($"{command[1]} was not found.");
                            }
                            break;
                        }
                    case "Error":
                        {
                            int index = int.Parse(command[1]);
                            if (friends[index] != "Blacklisted" && friends[index] != "Lost")
                            {
                                lostNames.Add(friends[index]);
                                Console.WriteLine($"{friends[index]} was lost due to an error.");
                                friends[index] = "Lost";
                            }
                            break;
                        }
                    case "Change":
                        {
                            int index = int.Parse(command[1]);
                            if(index >= 0 && index < friends.Count)
                            {
                                Console.WriteLine($"{friends[index]} changed his username to {command[2]}.");
                                friends[index] = command[2];
                            }
                            break;
                        }
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Blacklisted names: {blacklistedFriends.Count}");
            Console.WriteLine($"Lost names: {lostNames.Count}");
            Console.WriteLine(string.Join(' ', friends));

        }
    }
}
