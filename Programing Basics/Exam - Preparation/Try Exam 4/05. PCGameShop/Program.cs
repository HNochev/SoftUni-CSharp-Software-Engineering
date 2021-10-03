using System;

namespace _05._PCGameShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int countSoldGames = int.Parse(Console.ReadLine());
            double hearthstone = 0;
            double fortnite = 0;
            double overwatch = 0;
            double others = 0;

            for (int i = 0; i < countSoldGames; i++)
            {
                string nameGame = Console.ReadLine();
                switch (nameGame)
                {
                    case "Hearthstone":
                        {
                            hearthstone++;
                            break;
                        }
                    case "Fornite":
                        {
                            fortnite++;
                            break;
                        }
                    case "Overwatch":
                        {
                            overwatch++;
                            break;
                        }
                    default:
                        {
                            others++;
                            break;
                        }
                }
            }
            Console.WriteLine($"Hearthstone - {hearthstone/countSoldGames*100:f2}%");
            Console.WriteLine($"Fornite - {fortnite/countSoldGames*100:f2}%");
            Console.WriteLine($"Overwatch - {overwatch / countSoldGames * 100:f2}%");
            Console.WriteLine($"Others - {others / countSoldGames * 100:f2}%");
        }
    }
}
