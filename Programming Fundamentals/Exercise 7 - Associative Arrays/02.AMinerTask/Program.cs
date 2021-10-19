using System;
using System.Collections.Generic;

namespace _02.AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, int> result = new Dictionary<string, int>();

            while(input!="stop")
            {
                int resource = int.Parse(Console.ReadLine());

                if(result.ContainsKey(input))
                {
                    result[input] = result[input] + resource;
                }
                else
                {
                    result.Add(input, resource);
                }
                
                input = Console.ReadLine();
            }
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
