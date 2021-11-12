using System;
using System.IO;

namespace _6.FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            string folderPath = $"../../../TestFolder";

            var files = Directory.GetFiles(folderPath);

            double fileSizes = 0;

            foreach (var filePath in files)
            {
                FileInfo file = new FileInfo(filePath);

                Console.WriteLine(file.FullName);
                Console.WriteLine(file.Length);
                Console.WriteLine(file.Extension);
                Console.WriteLine(file.DirectoryName);

                fileSizes += file.Length;
            }
            Console.WriteLine(fileSizes / 1024 / 1024);
        }
    }
}