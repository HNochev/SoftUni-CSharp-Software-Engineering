using System;
using System.Text;

namespace _07.StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder sb = new StringBuilder();
            int strenght = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char current = input[i];

                if (current == '>')
                {
                    strenght = strenght + int.Parse(input[i + 1].ToString());
                    sb.Append(current);
                }
                else if (strenght == 0)
                {
                    sb.Append(current);
                }
                else
                {
                    strenght--;
                }
            }
            Console.WriteLine(sb);
        }
    }
}
