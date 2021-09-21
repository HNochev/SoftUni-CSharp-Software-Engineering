using System;

namespace _06._VowelsSum
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().ToLower();
            double finalSum = 0;

            for (int i = 0; i < text.Length; i++)
            {
                char momentLetter = text[i];

                switch(momentLetter)
                {
                    case 'a':
                        {
                            finalSum = finalSum + 1;
                            break;
                        }
                    case 'e':
                        {
                            finalSum = finalSum + 2;
                            break;
                        }
                    case 'i':
                        {
                            finalSum = finalSum + 3;
                            break;
                        }
                    case 'o':
                        {
                            finalSum = finalSum + 4;
                            break;
                        }
                    case 'u':
                        {
                            finalSum = finalSum + 5;
                            break;
                        }
                }
            }
            Console.WriteLine(finalSum);
        }
    }
}
