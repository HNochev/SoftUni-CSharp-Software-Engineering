using System;

namespace _09.PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double lightsaberPrice = double.Parse(Console.ReadLine());
            double robesPrice = double.Parse(Console.ReadLine());
            double beltsPrice = double.Parse(Console.ReadLine());

            double freeBelts = 0;
            for (int i = 1; i <= students; i++)
            {
                if (i % 6 == 0)
                {
                    freeBelts++;
                }
            }

            double fullLightsabers = students * 1.10;
            fullLightsabers = Math.Ceiling(fullLightsabers);

            double finalPrice = (students * robesPrice) + ((students - freeBelts) * beltsPrice) + (fullLightsabers * lightsaberPrice);



            if (money >= finalPrice)
            {
                Console.WriteLine($"The money is enough - it would cost {finalPrice:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {finalPrice - money:f2}lv more.");
            }
        }
    }
}
