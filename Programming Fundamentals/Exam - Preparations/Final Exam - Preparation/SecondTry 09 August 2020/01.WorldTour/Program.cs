using System;

namespace _01.WorldTour
{
    class Program
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();

            string[] command = Console.ReadLine()
                .Split(":", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "Travel")
            {
                switch (command[0])
                {
                    case "Add Stop":
                        {
                            int index = int.Parse(command[1]);
                            string str = command[2];

                            if (index >= 0 && index < stops.Length)
                            {
                                stops = stops.Insert(index, str);
                            }
                            Console.WriteLine(stops);
                            break;
                        }
                    case "Remove Stop":
                        {
                            int startIndex = int.Parse(command[1]);
                            int endIndex = int.Parse(command[2]);

                            if (startIndex >= 0 && startIndex < stops.Length && endIndex >= 0 && endIndex < stops.Length && startIndex <= endIndex)
                            {
                                string first = stops.Substring(0, startIndex);
                                string end = stops.Substring(endIndex + 1);

                                stops = first + end;
                            }
                            Console.WriteLine(stops);

                            break;
                        }
                    case "Switch":
                        {
                            stops = stops.Replace(command[1], command[2]);
                            Console.WriteLine(stops);
                            break;
                        }
                    default:
                        break;
                }

                command = Console.ReadLine()
                .Split(":", StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }
    }
}
