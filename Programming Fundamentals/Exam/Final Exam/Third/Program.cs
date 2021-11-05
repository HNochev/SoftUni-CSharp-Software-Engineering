using System;
using System.Collections.Generic;
using System.Linq;

namespace Third
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine()
                .Split("->", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, List<string>> usersMessages = new Dictionary<string, List<string>>();

            while(command[0] != "Statistics")
            {
                string username = command[1];
                switch (command[0])
                {
                    case "Add":
                        {
                            if(usersMessages.ContainsKey(username))
                            {
                                Console.WriteLine($"{username} is already registered");
                            }
                            else
                            {
                                usersMessages.Add(username, new List<string>());
                            }
                            break;
                        }
                    case "Send":
                        {
                            usersMessages[username].Add(command[2]);
                            break;
                        }
                    case "Delete":
                        {
                            if(usersMessages.ContainsKey(username))
                            {
                                usersMessages.Remove(username);
                            }
                            else
                            {
                                Console.WriteLine($"{username} not found!");
                            }
                            break;
                        }
                    default:
                        break;
                }

                command = Console.ReadLine()
                .Split("->", StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine($"Users count: {usersMessages.Count}");
            foreach (var user in usersMessages.OrderByDescending(x=>x.Value.Count).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{user.Key}");
                foreach (var item in user.Value)
                {
                    Console.WriteLine($" - {item}");
                }
            }
        }
    }
}
