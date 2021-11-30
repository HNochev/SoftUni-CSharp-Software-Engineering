using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            DarkWizard dw = new DarkWizard("Bgaming", 99);

            Console.WriteLine(dw);
        }
    }
}