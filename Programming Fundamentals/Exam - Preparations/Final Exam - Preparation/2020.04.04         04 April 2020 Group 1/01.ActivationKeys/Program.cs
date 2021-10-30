using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace _01.ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();

            string[] input = Console.ReadLine()
                .Split(">>>", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (input[0] != "Generate")
            {
                switch (input[0])
                {
                    case "Contains":
                        {
                            if(key.Contains(input[1]))
                            {
                                Console.WriteLine($"{key} contains {input[1]}");
                            }
                            else
                            {
                                Console.WriteLine($"Substring not found!");
                            }
                            break;
                        }
                    case "Flip":
                        {
                            int startIndex = int.Parse(input[2]);
                            int endIndex = int.Parse(input[3]);

                            string substr = key.Substring(startIndex, endIndex - startIndex);

                            if(input[1] == "Upper")
                            {
                                key = key.Replace(substr, substr.ToUpper());
                            }
                            else if(input[1] == "Lower")
                            {
                                key = key.Replace(substr, substr.ToLower());
                            }
                            Console.WriteLine(key);
                            break;
                        }
                    case "Slice":
                        {
                            int startIndex = int.Parse(input[1]);
                            int endIndex = int.Parse(input[2]);

                            key = key.Remove(startIndex, endIndex - startIndex);

                            Console.WriteLine(key);
                            break;
                        }
                }

                input = Console.ReadLine()
                .Split(">>>", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }
            Console.WriteLine($"Your activation key is: {key}");
        }
    }
}
