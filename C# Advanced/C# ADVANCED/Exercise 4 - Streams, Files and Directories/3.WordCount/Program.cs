using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _3.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = File.ReadAllLines("../../../words.txt");
            Dictionary<string, int> wordsCounts = new Dictionary<string, int>();

            foreach (var word in words)
            {
                wordsCounts.Add(word.ToLower(), 0);
            }

            string text = File.ReadAllText("../../../text.txt").ToLower();
            string[] textWords = text.Split(
                new string[] { " ", ",", ".", "!", "?", "-", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in textWords)
            {
                if (wordsCounts.ContainsKey(word))
                {
                    wordsCounts[word]++;
                }
            }

            Dictionary<string, int> sortedWords = wordsCounts
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);

            List<string> outputLines = sortedWords
                .Select(x => $"{x.Key} - {x.Value}")
                .ToList();

            File.WriteAllLines("../../../expectedResult.txt", outputLines);
        }
    }
}
