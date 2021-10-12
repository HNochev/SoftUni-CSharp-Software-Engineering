using System;

namespace _09.GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            
            switch (type)
            {
                case "int":
                    {
                        int a = int.Parse(Console.ReadLine());
                        int b = int.Parse(Console.ReadLine());
                        GetMax(a, b);
                        break;
                    }
                case "char":
                    {
                        char a = char.Parse(Console.ReadLine());
                        char b = char.Parse(Console.ReadLine());
                        GetMax(a, b);
                        break;
                    }
                case "string":
                    {
                        string a = Console.ReadLine();
                        string b = Console.ReadLine();
                        GetMax(a, b);
                        break;
                    }
            }
        }
        static void GetMax(int a, int b)
        {
            if (a >= b)
            {
                Console.WriteLine(a);
            }
            else
            {
                Console.WriteLine(b);
            }
        }
        static void GetMax(char a, char b)
        {
            if(a >= b)
            {
                Console.WriteLine(a);
            }
            else
            {
                Console.WriteLine(b);
            }
        }
        static void GetMax(string a, string b)
        {
            int comparison = string.Compare(a, b);

            if (comparison <= 0)
            {
                Console.WriteLine(b);
            }
            else if (comparison > 0)
            {
                Console.WriteLine(a);
            }
        }
    }
}
