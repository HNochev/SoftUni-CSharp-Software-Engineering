using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int pencilsCount = int.Parse(Console.ReadLine());
            int fulmasterCount = int.Parse(Console.ReadLine());
            int skicnikCount = int.Parse(Console.ReadLine());
            int notebooksCount = int.Parse(Console.ReadLine());

            double pp = pencilsCount * 4.75;
            double fp = fulmasterCount * 1.80;
            double sp = skicnikCount * 6.50;
            double np = notebooksCount * 2.50;

            double finalPrice = pp + fp + sp + np;
            finalPrice = finalPrice - ((finalPrice*5)/100);

            Console.WriteLine($"Your total is {finalPrice:f2}lv");
        }
    }
}
