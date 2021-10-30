using System;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace _02.EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            BigInteger coolThreshold = 1;

            string pattern = @"([:]{2}|[*]{2})(?<emoji>[A-Z][a-z]{2,})\1";
            Regex regex = new Regex(pattern);

            string numberPattern = @"[0-9]";
            Regex numberRegex = new Regex(numberPattern);

            MatchCollection matches = regex.Matches(str);
            MatchCollection numberMatches = numberRegex.Matches(str);

            foreach (Match number in numberMatches)
            {
                coolThreshold = coolThreshold * int.Parse(number.ToString());
            }

            Console.WriteLine($"Cool threshold: {coolThreshold}");

            Console.WriteLine($"{matches.Count} emojis found in the text. The cool ones are:");
            foreach (Match emoji in matches)
            {
                BigInteger emojiSum = 0;
                string emojiStr = emoji.Groups["emoji"].ToString();
                for (int i = 0; i < emojiStr.Length; i++)
                {
                    emojiSum = emojiSum + emojiStr[i];
                }
                if (emojiSum > coolThreshold)
                {
                    Console.WriteLine(emoji.ToString());
                }
            }

        }
    }
}
