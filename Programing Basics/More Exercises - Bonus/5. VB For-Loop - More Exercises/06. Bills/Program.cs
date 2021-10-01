using System;

namespace _06._Bills
{
    class Program
    {
        static void Main(string[] args)
        {
            int countMoths = int.Parse(Console.ReadLine());
            double waterBill = 0;
            double fullElecticityBill = 0;
            double internetBill = 0;
            double everythingWith20 = 0;
            double final = 0;

            for (int i = 0; i < countMoths; i++)
            {
                double electricityBill = double.Parse(Console.ReadLine());
                fullElecticityBill = fullElecticityBill + electricityBill;
                waterBill = waterBill + 20;
                internetBill = internetBill + 15;
                everythingWith20 = (fullElecticityBill + waterBill + internetBill) * 1.20;
            }
            final = (fullElecticityBill + waterBill + internetBill + everythingWith20) / countMoths;
            Console.WriteLine($"Electricity: {fullElecticityBill:f2} lv");
            Console.WriteLine($"Water: {waterBill:f2} lv");
            Console.WriteLine($"Internet: {internetBill:f2} lv");
            Console.WriteLine($"Other: {everythingWith20:f2} lv");
            Console.WriteLine($"Average: {final:f2} lv");
        }
    }
}
