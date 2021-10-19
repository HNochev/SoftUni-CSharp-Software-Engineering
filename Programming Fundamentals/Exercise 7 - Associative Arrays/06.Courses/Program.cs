using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            while(input != "end")
            {
                string[] text = input
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                string course = text[0];
                string student = text[1];

                if(!courses.ContainsKey(course))
                {
                    courses.Add(course, new List<string>());
                }
                courses[course].Add(student);

                input = Console.ReadLine();
            }

            foreach (var item in courses.OrderByDescending(x=>x.Value.Count))
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");


                foreach (var student in item.Value.OrderBy(x=>x))
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
