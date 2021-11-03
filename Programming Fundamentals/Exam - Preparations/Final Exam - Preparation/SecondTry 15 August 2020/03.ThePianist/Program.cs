using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ThePianist
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> pieces = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);

                pieces.Add(line[0], new List<string>());
                pieces[line[0]].Add(line[1]);
                pieces[line[0]].Add(line[2]);
            }

            string[] command = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "Stop")
            {
                switch (command[0])
                {
                    case "Add":
                        {
                            if (pieces.ContainsKey(command[1]))
                            {
                                Console.WriteLine($"{command[1]} is already in the collection!");
                            }
                            else
                            {
                                Console.WriteLine($"{command[1]} by {command[2]} in {command[3]} added to the collection!");
                                pieces.Add(command[1], new List<string>());
                                pieces[command[1]].Add(command[2]);
                                pieces[command[1]].Add(command[3]);
                            }
                            break;
                        }
                    case "Remove":
                        {
                            if (pieces.ContainsKey(command[1]))
                            {
                                Console.WriteLine($"Successfully removed {command[1]}!");
                                pieces.Remove(command[1]);
                            }
                            else
                            {
                                Console.WriteLine($"Invalid operation! {command[1]} does not exist in the collection.");
                            }
                            break;
                        }
                    case "ChangeKey":
                        {
                            if (pieces.ContainsKey(command[1]))
                            {
                                pieces[command[1]][1] = command[2];
                                Console.WriteLine($"Changed the key of {command[1]} to {command[2]}!");
                            }
                            else
                            {
                                Console.WriteLine($"Invalid operation! {command[1]} does not exist in the collection.");
                            }
                            break;
                        }
                    default:
                        break;
                }

                command = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries);
            }
            foreach (var item in pieces.OrderBy(x=>x.Key).ThenBy(x=>x.Value[0]))
            {
                Console.WriteLine($"{item.Key} -> Composer: {item.Value[0]}, Key: {item.Value[1]}");
            }
        }
    }
}
