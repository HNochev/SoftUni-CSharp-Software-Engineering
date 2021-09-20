using System;

namespace _08.Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double avgGrade = double.Parse(Console.ReadLine());
            double minimalSalary = double.Parse(Console.ReadLine());

            double socialScoolarship = minimalSalary * 0.35;
            double excelentStudentSchoolarship = avgGrade * 25;

            if(income >= minimalSalary && avgGrade >=5.50)
            {
                Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(excelentStudentSchoolarship)} BGN");
            }
            else if (income >= minimalSalary && avgGrade < 5.5)
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
            else if(income < minimalSalary && avgGrade >= 5.5 && socialScoolarship <= excelentStudentSchoolarship)
            {
                Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(excelentStudentSchoolarship)} BGN");
            }
            else if (income < minimalSalary && avgGrade > 4.5)
            {
                Console.WriteLine($"You get a Social scholarship {Math.Floor(socialScoolarship)} BGN");
            }
            else if (income < minimalSalary && avgGrade <= 4.5)
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
        }
    }
}