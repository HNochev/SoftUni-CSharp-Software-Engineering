using System;

namespace _03.ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string location = Console.ReadLine();

            int index = location.LastIndexOf('\\');
            int index2 = location.LastIndexOf('.');

            Console.WriteLine($"File name: {location.Substring(index + 1, index2 - (index + 1))}");
            Console.WriteLine($"File extension: {location.Substring(index2 + 1)}");
        }
    }
}
