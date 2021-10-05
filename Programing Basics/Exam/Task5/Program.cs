using System;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string card = "";
            int pastSeconds = int.MaxValue;
            string finalName = "";

            int gold = 0;
            int silver = 0;
            int bronze = 0;


            while (name != "Finish")
            {
                int minutes = int.Parse(Console.ReadLine());
                int seconds = int.Parse(Console.ReadLine());

                int fullSeconds = minutes * 60 + seconds;

                if(fullSeconds < 55)
                {
                    gold++;
                }
                else if(fullSeconds >= 55 && fullSeconds <= 85)
                {
                    silver++;
                }
                else if(fullSeconds > 85 && fullSeconds <= 120)
                {
                    bronze++;
                }
                if(fullSeconds < pastSeconds)
                {
                    finalName = name;
                    pastSeconds = fullSeconds;
                }
                name = Console.ReadLine();
            }
            Console.WriteLine($"With {pastSeconds/60} minutes and {pastSeconds%60} seconds {finalName} is the winner of the day!");
            Console.WriteLine($"Today's prizes are {gold} Gold {silver} Silver and {bronze} Bronze cards!");
        }
    }
}
