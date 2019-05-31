using System;
using System.IO;
using System.IO.Compression;

namespace _06._Zip_and_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            

            var zipFile = @"..\..\..\Result.zip";
            var file = "copyMe.png";

            using (var archive = ZipFile.Open(zipFile, ZipArchiveMode.Create))
            {
                
                    archive.CreateEntryFromFile(file, Path.GetFileName(file));
                
            }
        }

    }
}

