using System;
using System.IO;

namespace _1.OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../input.txt"))
            {
                string currentRow = reader.ReadLine();
                int count = 0;
                using (StreamWriter writer = new StreamWriter("../../../output.txt"))
                {
                    while (currentRow != null)
                    {
                        if (count % 2 == 1)
                        {
                            writer.WriteLine(currentRow);
                        }
                        currentRow = reader.ReadLine();
                        count++;
                    }
                }
            }
        }
    }
}
