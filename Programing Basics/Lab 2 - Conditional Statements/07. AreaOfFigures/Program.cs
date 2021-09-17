using System;

namespace _07._AreaOfFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();

            if(figure.ToLower() == "square")
            {
                double a = double.Parse(Console.ReadLine());
                double area = a * a;

                Console.WriteLine($"{area:f3}");
            }
            else if(figure.ToLower() == "rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                double area = a * b;

                Console.WriteLine($"{area:f3}");
            }
            else if(figure.ToLower() == "circle")
            {
                double r = double.Parse(Console.ReadLine());
                double area = r * r * Math.PI;

                Console.WriteLine($"{area:f3}");
            }
            else if(figure.ToLower() == "triangle")
            {
                double a = double.Parse(Console.ReadLine());
                double h = double.Parse(Console.ReadLine());
                double area = (a * h) / 2;

                Console.WriteLine($"{area:f3}");
            }
        }
    }
}
