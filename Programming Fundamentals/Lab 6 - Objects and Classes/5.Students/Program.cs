using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _5.Students
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Student> students = new List<Student>();

            while (input != "end")
            {
                string[] inputItems = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string fName = inputItems[0];
                string lName = inputItems[1];
                int age = int.Parse(inputItems[2]);
                string town = inputItems[3];

                Student student = new Student();
                {
                    student.FirstName = fName;
                    student.LastName = lName;
                    student.Age = age;
                    student.Town = town;
                }

                students.Add(student);
                input = Console.ReadLine();
            }

            string enteredTown = Console.ReadLine();

            List<Student> result = students
                .Where(n => n.Town == enteredTown)
                .ToList();

            foreach (Student item in result)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName} is {item.Age} years old.");
            }
        }
    }
}
