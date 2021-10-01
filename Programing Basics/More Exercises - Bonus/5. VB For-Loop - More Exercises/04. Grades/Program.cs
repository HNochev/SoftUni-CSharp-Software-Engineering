using System;

namespace _04._Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());
            double two = 0;
            double three = 0;
            double four = 0;
            double five = 0;
            double fullGrade = 0;

            for (int i = 0; i < students; i++)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade >= 5)
                {
                    five++;
                }
                else if (grade >= 4 && grade < 5)
                {
                    four++;
                }
                else if (grade >= 3 && grade < 4)
                {
                    three++;
                }
                else if (grade < 3)
                {
                    two++;
                }
                fullGrade = fullGrade + grade;
            }
            fullGrade = fullGrade / students;
            Console.WriteLine($"Top students: {five/students*100:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {four/students*100:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {three/students*100:f2}%");
            Console.WriteLine($"Fail: {two/students*100:f2}%");
            Console.WriteLine($"Average: {fullGrade:f2}");
        }
    }
}
