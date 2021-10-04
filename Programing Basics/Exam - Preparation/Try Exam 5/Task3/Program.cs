using System;
using System.Linq;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "Hello My naMe Is HrisTiyAn";

            int answer = str.Where(x => Char.IsUpper(x)).Count();

            Console.WriteLine(answer);
        }
    }
}
