using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, int> students = new Dictionary<string, int>();
            Dictionary<string, int> submissions = new Dictionary<string, int>();

            while (input != "exam finished")
            {
                string[] command = input
                    .Split('-', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string username = command[0];
                if (command.Length > 2)
                {
                    string language = command[1];
                    int points = int.Parse(command[2]);

                    if (!students.ContainsKey(username))
                    {
                        students.Add(username, points);
                    }
                    else
                    {
                        if(students[username] < points)
                        {
                            students[username] = points;
                        }
                    }

                    if(!submissions.ContainsKey(language))
                    {
                        submissions.Add(language, 0);
                    }
                    submissions[language]++;
                }
                else
                {
                    students.Remove(username);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("Results:");
            foreach (var item in students.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key} | {item.Value}");
            }
            Console.WriteLine("Submissions:");
            foreach (var item in submissions.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}
