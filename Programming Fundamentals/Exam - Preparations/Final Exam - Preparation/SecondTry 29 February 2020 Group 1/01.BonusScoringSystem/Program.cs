using System;

namespace _01.BonusScoringSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();

            string[] command = Console.ReadLine()
                .Split(">>>", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "Generate")
            {
                switch (command[0])
                {
                    case "Contains":
                        {
                            if (key.Contains(command[1]))
                            {
                                Console.WriteLine($"{key} contains {command[1]}");
                            }
                            else
                            {
                                Console.WriteLine("Substring not found!");
                            }
                            break;
                        }
                    case "Flip":
                        {
                            int stratIndex = int.Parse(command[2]);
                            int endIndex = int.Parse(command[3]);
                            string begining = key.Substring(0, stratIndex);
                            string ending = key.Substring(endIndex);

                            string middle = key.Substring(stratIndex, endIndex - stratIndex);

                            if (command[1] == "Upper")
                            {
                                middle = middle.ToUpper();
                            }
                            else if (command[1] == "Lower")
                            {
                                middle = middle.ToLower();
                            }
                            key = begining + middle + ending;
                            Console.WriteLine(key);
                            break;
                        }
                    case "Slice":
                        {
                            int stratIndex = int.Parse(command[1]);
                            int endIndex = int.Parse(command[2]);
                            string begining = key.Substring(0, stratIndex);
                            string ending = key.Substring(endIndex);

                            key = begining + ending;
                            Console.WriteLine(key);
                            break;
                        }
                    default:
                        break;
                }

                command = Console.ReadLine()
                .Split(">>>", StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine($"Your activation key is: {key}");
        }
    }
}
