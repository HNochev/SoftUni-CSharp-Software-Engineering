using System;
using System.Text.RegularExpressions;

namespace _06.ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string emails = Console.ReadLine();

            string pattern = @"(^|(?<=\s))(([a-zA-Z0-9]+)([\.\-_]?)([A-Za-z0-9]+)(@)([a-zA-Z]+([\.\-_][A-Za-z]+)+))(\b|(?=\s))";
            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(emails);



            foreach (Match item in matches)
            {
                Console.WriteLine(item.Value.Trim());
            }
        }
    }
}
