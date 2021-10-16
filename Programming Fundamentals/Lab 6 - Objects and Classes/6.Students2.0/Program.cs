using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.Students2._0
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

                if (IsStudentExist(students, fName, lName))
                {
                    Student student = GetStudent(students, fName, lName);

                    student.FirstName = fName;
                    student.LastName = lName;
                    student.Age = age;
                    student.Town = town;
                }
                else
                {
                    Student student = new Student();
                    {
                        student.FirstName = fName;
                        student.LastName = lName;
                        student.Age = age;
                        student.Town = town;
                    };

                    students.Add(student);
                }
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

        static bool IsStudentExist(List<Student> students, string firstName, string lastName)
        {
            foreach (Student student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    return true;
                }
            }
            return false;
        }

        static Student GetStudent(List<Student> students, string firstName, string lastName)
        {
            Student existingStudent = null;

            foreach (Student item in students)
            {
                if (item.FirstName == firstName && item.LastName == lastName)
                {
                    existingStudent = item;
                }
            }
            return existingStudent;
        }
    }
}
