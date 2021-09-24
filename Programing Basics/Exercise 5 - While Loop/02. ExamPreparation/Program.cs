using System;

namespace _02._ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int countNotGoodGrades = int.Parse(Console.ReadLine());
            string excercise = Console.ReadLine();
            double score = int.Parse(Console.ReadLine());
            int badGrades = 0;
            double finalScore = 0;
            int counter = 0;
            string lastExcercice = "";

            while (excercise != "Enough")
            {
                if(score <= 4)
                {
                    badGrades++;
                    if(badGrades == countNotGoodGrades)
                    {
                        Console.WriteLine($"You need a break, {badGrades} poor grades.");
                        break;
                    }
                }
                finalScore = finalScore + score;
                counter++;
                lastExcercice = excercise;
                excercise = Console.ReadLine();
                if(excercise == "Enough")
                {
                    break;
                }
                score = double.Parse(Console.ReadLine());
            }
            finalScore = finalScore / counter;
            if (excercise == "Enough")
            {
                Console.WriteLine($"Average score: {finalScore:f2}");
                Console.WriteLine($"Number of problems: {counter}");
                Console.WriteLine($"Last problem: {lastExcercice}");
            }
        }
    }
}
