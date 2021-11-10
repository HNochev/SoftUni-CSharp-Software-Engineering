using System;
using System.Collections.Generic;

namespace _06.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            HashSet<string> licensePlates = new HashSet<string>();

            while (input[0] != "END")
            {
                if (input[0] == "IN")
                {
                    licensePlates.Add(input[1]);
                }
                else if (input[0] == "OUT")
                {
                    licensePlates.Remove(input[1]);
                }

                input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }

            if (licensePlates.Count > 0)
            {
                foreach (var plate in licensePlates)
                {
                    Console.WriteLine(plate);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
