using System;
using System.IO;
using System.IO.Compression;

namespace _6.ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            using ZipArchive zipFile = ZipFile.Open("../../../zipfile.zip", ZipArchiveMode.Create);
            ZipArchiveEntry zipArchiveEntry = zipFile.CreateEntryFromFile("../../../copyMe.png", "result.png");
        }
    }
}
