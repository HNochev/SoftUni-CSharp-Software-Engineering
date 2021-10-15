using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
               .Split(new Char[] {'|'}, StringSplitOptions.RemoveEmptyEntries)
               .ToList();

            list.Reverse();

            List<string> newList = new List<string>();
            List<string> result = new List<string>();

            for (int i = 0; i < list.Count; i++)
            {
                newList = list[i].Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                for (int j = 0; j < newList.Count; j++)
                {
                    result.Add(newList[j]);
                }
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
