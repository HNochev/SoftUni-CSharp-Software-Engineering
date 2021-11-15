using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> invitationList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string[] command = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            List<string> filters = new List<string>();

            while (command[0] != "Print")
            {
                string commandName = command[0];
                string filterType = command[1];
                string argument = command[2];

                switch (command[0])
                {
                    case "Add filter":
                        {
                            filters.Add($"{filterType};{argument}");
                            break;
                        }
                    case "Remove filter":
                        {
                            filters.Remove($"{filterType};{argument}");
                            break;
                        }
                }

                command = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (string filterLine in filters)
            {
                string[] tokens = filterLine.Split(";");
                string filterType = tokens[0];
                string argument = tokens[1];

                switch (filterType)
                {
                    case "Starts with":
                        {
                            invitationList = invitationList.Where(p => !p.StartsWith(argument)).ToList();
                            break;
                        }
                    case "Ends with":
                        {
                            invitationList = invitationList.Where(p => !p.EndsWith(argument)).ToList();
                            break;
                        }
                    case "Length":
                        {
                            invitationList = invitationList.Where(p => p.Length != int.Parse(argument)).ToList();
                            break;
                        }
                    case "Contains":
                        {
                            invitationList = invitationList.Where(p => !p.Contains(argument)).ToList();
                            break;
                        }
                }
            }
            Console.WriteLine(string.Join(" ", invitationList));
        }
    }
}