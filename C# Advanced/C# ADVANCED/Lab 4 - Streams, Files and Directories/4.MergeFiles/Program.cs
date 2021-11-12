using System;
using System.IO;

namespace _4.MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] file1 = File.ReadAllLines("../../../FileOne.txt");
            string[] file2 = File.ReadAllLines("../../../FileTwo.txt");

            using (StreamWriter writer = File.CreateText("../../../MergedFile.txt"))
            {
                int lineNum = 0;
                while (lineNum < file1.Length || lineNum < file2.Length)
                {
                    if (lineNum < file1.Length)
                        writer.WriteLine(file1[lineNum]);
                    if (lineNum < file2.Length)
                        writer.WriteLine(file2[lineNum]);
                    lineNum++;
                }
            }
        }
    }
}
