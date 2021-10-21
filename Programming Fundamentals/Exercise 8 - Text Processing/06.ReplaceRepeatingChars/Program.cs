using System;
using System.Text;

namespace _06.ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                if(i == text.Length-1)
                {
                    sb.Append(text[i]);
                    break;
                }
                if(text[i] != text[i+1])
                {
                    sb.Append(text[i]);
                }
            }
            Console.WriteLine(sb);
        }
    }
}
