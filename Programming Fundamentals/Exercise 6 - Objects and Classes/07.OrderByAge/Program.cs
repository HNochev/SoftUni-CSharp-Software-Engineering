using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Student> students = new List<Student>();

            while(command != "End")
            {
                string[] input = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Student stud = new Student(input[0], input[1], int.Parse(input[2]));
                students.Add(stud);

                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(Environment.NewLine,students.OrderBy(x=>x.Age)));
        }
    }
    class Student
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }

        public Student(string name, string id, int age)
        {
            this.Name = name;
            this.ID = id;
            this.Age = age;
        }

        public override string ToString()
        {
            return $"{Name} with ID: {ID} is {Age} years old.";
        }
    }
}
