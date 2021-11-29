using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList<string> list = new RandomList<string>()
            { "Amy",
            "Bet",
            "Sharon",
            "Zed",
            "Ben",
            "Nat"
            };

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(list.RandomString());
            }

        }
    }
}
