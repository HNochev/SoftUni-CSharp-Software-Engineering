using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text.RegularExpressions;

namespace _02.MirrorWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            List<string> mirrorWords = new List<string>();

            string pattern = @"(\@|\#)(?<word1>[A-Za-z]{3,})\1{2}(?<word2>[A-Za-z]{3,})\1";
            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(text);

            foreach (Match item in matches)
            {
                string word1 = item.Groups["word1"].Value;
                string word2 = item.Groups["word2"].Value;
                string word2Reversed = new string(item.Groups["word2"].Value.Reverse().ToArray());

                if(word1 == word2Reversed)
                {
                    mirrorWords.Add($"{word1} <=> {word2}");
                }
            }

            if(matches.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
            }

            if(mirrorWords.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", mirrorWords));
            }
        }
    }
}
