using System;

namespace _05._CharacterSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            for(int i = 0; i < text.Length; i++)
            {
                char momentLetter = text[i];
                Console.WriteLine(momentLetter);
            }
        }
    }
}
