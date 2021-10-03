using System;

namespace _06._TournamentOfChristmas
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double finalBalance = 0;
            double winnerDays = 0;
            double loserDays = 0;

            for (int i = 1; i <= days; i++)
            {
                string sport = Console.ReadLine();
                int wins = 0;
                int loses = 0;
                double todayMoney = 0;
                while (sport != "Finish")
                {
                    string winLose = Console.ReadLine();
                    if (winLose == "win")
                    {
                        todayMoney = todayMoney + 20;
                        wins++;
                    }
                    else if (winLose == "lose")
                    {
                        loses++;
                    }
                    sport = Console.ReadLine();
                }
                if (wins > loses)
                {
                    todayMoney = todayMoney * 1.10;
                    winnerDays++;
                }
                else
                {
                    loserDays++;
                }
                finalBalance = finalBalance + todayMoney;
            }
            if (winnerDays > loserDays)
            {
                finalBalance = finalBalance * 1.20;
                Console.WriteLine($"You won the tournament! Total raised money: {finalBalance:f2}");
            }
            else
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {finalBalance:f2}");
            }
        }
    }
}
