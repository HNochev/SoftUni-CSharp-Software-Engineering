using System;

namespace _07.ConcatNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string familyName = Console.ReadLine();
            string delimiter = Console.ReadLine();

            Console.WriteLine($"{firstName}{delimiter}{familyName}");
        }
    }
}
