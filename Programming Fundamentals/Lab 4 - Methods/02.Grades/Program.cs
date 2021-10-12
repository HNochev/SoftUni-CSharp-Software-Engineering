using System;

namespace _02.Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());
            Print(grade);
        }

        static void Print(double grades)
        {
            string text = string.Empty;

            if(grades >= 2 && grades <= 2.99)
            {
                text = "Fail";
            }
            else if (grades >= 3 && grades <= 3.49)
            {
                text = "Poor";
            }
            else if (grades >= 3.50 && grades <= 4.49)
            {
                text = "Good";
            }
            else if (grades >= 4.50 && grades <= 5.49)
            {
                text = "Very good";
            }
            else if (grades >= 5.50 && grades <= 6.00)
            {
                text = "Excellent";
            }
            Console.WriteLine(text);
        }
    }
}
