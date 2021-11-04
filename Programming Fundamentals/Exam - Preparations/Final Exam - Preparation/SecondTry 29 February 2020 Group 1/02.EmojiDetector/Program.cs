using System;
using System.Text.RegularExpressions;

namespace _02.EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string pattern = @"(\:{2}|\*{2})(?<emoji>[A-Z][a-z]{2,})\1";
            string numbersPattern = @"[0-9]";

            Regex emojiRegex = new Regex(pattern);
            Regex numbersRegex = new Regex(numbersPattern);

            MatchCollection emojies = emojiRegex.Matches(text);
            MatchCollection numbers = numbersRegex.Matches(text);
            long coolTreshold = 1;
            foreach (Match item in numbers)
            {
                coolTreshold = coolTreshold * int.Parse(item.Value);
            }
            Console.WriteLine($"Cool threshold: {coolTreshold}");
            Console.WriteLine($"{emojies.Count} emojis found in the text. The cool ones are:");
            foreach (Match emoji in emojies)
            {
                string emoj = emoji.Groups["emoji"].Value;
                long emojiSum = 0;
                for (int i = 0; i < emoj.Length; i++)
                {
                    emojiSum = emojiSum + emoj[i];
                }
                if(emojiSum > coolTreshold)
                {
                    Console.WriteLine(emoji.Value);
                }
            }
        }
    }
}
