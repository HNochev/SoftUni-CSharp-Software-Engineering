using System;

namespace _08._GraduationPt._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double finalScore = 0;
            int tries = 0;
            int i = 0;

            for (i = 0; i < 12; i++)
            {
                double score = double.Parse(Console.ReadLine());
                if(score < 4)
                {
                    tries++;
                    score = 0;
                    if(tries == 2)
                    {
                        break;
                    }
                }
                finalScore = finalScore + score;
            }
            if (i == 12)
            {
                finalScore = finalScore / i;
                Console.WriteLine($"{name} graduated. Average grade: {finalScore:f2}");
            }
            else
            {
                Console.WriteLine($"{name} has been excluded at {i} grade");
            }
        }
    }
}
