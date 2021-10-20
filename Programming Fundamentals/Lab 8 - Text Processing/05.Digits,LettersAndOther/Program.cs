using System;
using System.Text;

namespace _05.Digits_LettersAndOther
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder sbDigits = new StringBuilder();
            StringBuilder sbLetters = new StringBuilder();
            StringBuilder sbNonDigOrLetters = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                if(Char.IsDigit(text[i]))
                {
                    sbDigits.Append(text[i]);
                }
                else if(Char.IsLetter(text[i]))
                {
                    sbLetters.Append(text[i]);
                }
                else
                {
                    sbNonDigOrLetters.Append(text[i]);
                }
            }
            Console.WriteLine(sbDigits);
            Console.WriteLine(sbLetters);
            Console.WriteLine(sbNonDigOrLetters);
        }
    }
}
