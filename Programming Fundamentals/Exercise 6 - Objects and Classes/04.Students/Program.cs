using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int countStudents = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();

            for (int i = 0; i < countStudents; i++)
            {
                string[] data = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string fName = data[0];
                string sName = data[1];
                double grade = double.Parse(data[2]);

                Student st = new Student(fName, sName, grade);

                students.Add(st);
            }

            Console.WriteLine(string.Join(Environment.NewLine, students.OrderByDescending(x => x.Grade)));
        }
    }
    class Student
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public double Grade { get; set; }
        public Student(string firstName, string secondName, double grade)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.Grade = grade;
        }
        public override string ToString()
        {
            string text = ($"{FirstName} {SecondName}: {Grade:f2}");

            return text;
        }
    }
}
