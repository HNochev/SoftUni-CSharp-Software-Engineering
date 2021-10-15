using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> schedule = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();


            while (input != "course start")
            {
                string[] command = input
                    .Split(':', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (command[0] == "Add")
                {
                    if (!schedule.Contains(command[1]))
                    {
                        schedule.Add(command[1]);
                    }
                }
                else if (command[0] == "Insert")
                {
                    if (!schedule.Contains(command[1]))
                    {
                        schedule.Insert(int.Parse(command[2]), command[1]);
                    }
                }
                else if (command[0] == "Remove")
                {
                    if (schedule.Contains(command[1]))
                    {
                        schedule.Remove(command[1]);
                    }
                }
                else if (command[0] == "Swap")
                {
                    if (schedule.Contains(command[1]) && schedule.Contains(command[2]))
                    {
                        int command1Index = schedule.IndexOf(command[1]);
                        int command2Index = schedule.IndexOf(command[2]);

                        string[] nextCommand1 = new string[2];
                        string[] nextCommand2 = new string[2];

                        if ((command1Index + 1) < schedule.Count && (command2Index + 1) < schedule.Count)
                        {
                            nextCommand1 = schedule[command1Index + 1].Split('-', StringSplitOptions.RemoveEmptyEntries).ToArray();
                            nextCommand2 = schedule[command2Index + 1].Split('-', StringSplitOptions.RemoveEmptyEntries).ToArray();
                        }

                        schedule[command1Index] = command[2];
                        schedule[command2Index] = command[1];

                        if (nextCommand1.Contains("Exercise"))
                        {
                            schedule.Remove(string.Join('-', nextCommand1));
                            command1Index = schedule.IndexOf(command[1]);
                            schedule.Insert(command1Index + 1, string.Join('-', nextCommand1));
                        }
                        if (nextCommand2.Contains("Exercise"))
                        {
                            schedule.Remove(string.Join('-', nextCommand2));
                            command2Index = schedule.IndexOf(command[2]);
                            schedule.Insert(command2Index + 1, string.Join('-', nextCommand2));
                        }

                    }
                }
                else if (command[0] == "Exercise")
                {
                    string excercise = string.Join('-', command.Reverse());

                    if (schedule.Contains(command[1]) && !schedule.Contains(excercise))
                    {
                        int indexOfCommand1 = schedule.IndexOf(command[1]);
                        schedule.Insert(indexOfCommand1 + 1, excercise);
                    }
                    else if (!schedule.Contains(command[1]) && !schedule.Contains(excercise))
                    {
                        schedule.Add(command[1]);
                        schedule.Add(excercise);
                    }
                }
                input = Console.ReadLine();
            }
            int counter = 1;
            foreach (var item in schedule)
            {
                Console.WriteLine($"{counter}.{item}");
                counter++;
            }
        }
    }
}
