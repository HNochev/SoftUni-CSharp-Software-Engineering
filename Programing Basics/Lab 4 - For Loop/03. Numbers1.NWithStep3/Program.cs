﻿using System;

namespace _03._Numbers1.NWithStep3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i = i + 3)
            {
                Console.WriteLine(i);
            }
        }
    }
}
