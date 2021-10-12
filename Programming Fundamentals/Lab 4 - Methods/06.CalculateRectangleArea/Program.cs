using System;

namespace _06.CalculateRectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            int result = Area(width, height);
            Console.WriteLine(result);
        }

        static int Area(int a, int b)
        {
            return a * b;
        }
    }
}
