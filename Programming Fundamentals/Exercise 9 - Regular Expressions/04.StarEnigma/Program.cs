using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04.StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> APlanets = new List<string>();
            List<string> DPlanets = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                StringBuilder sb = new StringBuilder();

                string pattern = @"[SsTtAaRr]";
                Regex regex = new Regex(pattern);
                MatchCollection matches = regex.Matches(input);

                for (int j = 0; j < input.Length; j++)
                {
                    char a = (char)(input[j] - matches.Count);
                    sb.Append(a);
                }
                string text = sb.ToString();
                sb.Clear();

                string patternNew = @"@(?<planetName>[A-Za-z]+)[^\@\-\!\:\>]*:(?<population>[0-9]+)[^\@\-\!\:\>]*!(?<attakType>[AD])![^\@\-\!\:\>]*->(?<soilders>[0-9]+)";
                Regex regexNew = new Regex(patternNew);
                Match match = regexNew.Match(text);

                if (match.Success)
                {
                    string type = match.Groups["attakType"].Value;
                    string name = match.Groups["planetName"].Value;

                    if (type == "A")
                    {
                        APlanets.Add(name);
                    }
                    else if (type == "D")
                    {
                        DPlanets.Add(name);
                    }
                }

            }
            Console.WriteLine($"Attacked planets: {APlanets.Count}");
            foreach (var planet in APlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planet}");
            }
            Console.WriteLine($"Destroyed planets: {DPlanets.Count}");
            foreach (var planet in DPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planet}");
            }
        }
    }
}
