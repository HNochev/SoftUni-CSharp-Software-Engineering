using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string[] student = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if(!students.ContainsKey(student[0]))
                {
                    students.Add(student[0], new List<double>());
                }
                students[student[0]].Add(double.Parse(student[1]));
            }
            foreach (var student in students)
            {
                Console.Write($"{student.Key} -> ");
                for (int i = 0; i < student.Value.Count; i++)
                {
                    Console.Write($"{student.Value[i]:f2} ");
                }
                Console.WriteLine($"(avg: {student.Value.Average():f2})");
            }
        }
    }
}
