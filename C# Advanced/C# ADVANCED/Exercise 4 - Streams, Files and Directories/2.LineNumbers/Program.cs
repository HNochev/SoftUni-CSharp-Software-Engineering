using System;
using System.IO;
using System.Linq;

namespace _2.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../text.txt");
            int counter = 0;
            int lettersCount = 0;
            int punctuationCount = 0;

            string[] newLines = new string[lines.Length];

            foreach (var line in lines)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (char.IsLetter(line[i]))
                    {
                        lettersCount++;
                    }
                    if (char.IsPunctuation(line[i]))
                    {
                        punctuationCount++;
                    }
                }
                newLines[counter] = $"Line {counter + 1}: {lines[counter]}({lettersCount})({punctuationCount})";

                lettersCount = 0;
                punctuationCount = 0;
                counter++;
            }
            File.WriteAllLines("../../../output.txt", newLines);
        }
    }
}
