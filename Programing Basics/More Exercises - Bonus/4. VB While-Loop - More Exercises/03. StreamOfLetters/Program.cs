using System;

namespace StreamOfLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            string symbol = Console.ReadLine();

            int counterC = 0;
            int counterO = 0;
            int counterN = 0;
            string word = string.Empty;
            string secredWord = string.Empty;


            while (symbol != "End")
            {

                char letter = char.Parse(symbol);

                if (letter >= 'a' && letter <= 'z' || letter >= 'A' && letter <= 'Z')
                {
                    if (symbol == "c" && counterC == 0)
                    {
                        counterC++;
                    }
                    else if (symbol == "o" && counterO == 0)
                    {
                        counterO++;
                    }
                    else if (symbol == "n" && counterN == 0)
                    {
                        counterN++;
                    }
                    else
                    {
                        word += letter;
                    }
                    if (counterC + counterN + counterO == 3)
                    {
                        secredWord += word;
                        secredWord += ' ';
                        word = string.Empty;
                        counterO = 0;
                        counterC = 0;
                        counterN = 0;
                    }

                }

                symbol = Console.ReadLine();
            }

            Console.WriteLine(secredWord);

        }
    }
}