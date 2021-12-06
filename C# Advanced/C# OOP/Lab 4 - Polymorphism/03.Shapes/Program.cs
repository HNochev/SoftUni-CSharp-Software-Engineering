using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape rectangle = new Rectangle(2, 3);

            Console.WriteLine(rectangle.CalculatePerimeter());
            Console.WriteLine(rectangle.CalculateArea());
            Console.WriteLine(rectangle.Draw());

            Console.WriteLine();

            Shape circle = new Circle(4);

            Console.WriteLine($"{circle.CalculatePerimeter():f2}");
            Console.WriteLine($"{circle.CalculateArea():f2}");
            Console.WriteLine(circle.Draw());
        }
    }
}
