using System;

namespace _04._TrainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int countJudges = int.Parse(Console.ReadLine());
            string text = Console.ReadLine();
            double finalMark = 0;
            double finalFinalMark = 0;
            int allMarks = 0;

            while (text != "Finish")
            {
                for (int i = 0; i < countJudges; i++)
                {
                    double mark = double.Parse(Console.ReadLine());
                    finalMark = finalMark + mark;
                    allMarks++;
                }
                Console.WriteLine($"{text} - {finalMark/countJudges:f2}.");
                finalFinalMark = finalFinalMark + finalMark;
                finalMark = 0;
                text = Console.ReadLine();
            }
            Console.WriteLine($"Student's final assessment is {finalFinalMark/allMarks:f2}.");
        }
    }
}
