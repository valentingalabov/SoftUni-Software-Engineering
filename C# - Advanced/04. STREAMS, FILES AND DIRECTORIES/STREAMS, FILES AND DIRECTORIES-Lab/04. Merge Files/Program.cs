using System;
using System.Collections.Generic;
using System.IO;

namespace _04._Merge_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathFolder = "Files";
            string firstFile = "FileOne.txt";
            string secondFile = "FileTwo.txt";
            string outputFile = "Output.txt";
            List<string> result1 = new List<string>();
            List<string> result2 = new List<string>();

            using (var readerFirsFile = new StreamReader(Path.Combine(pathFolder, firstFile)))
            {
                string currLine = readerFirsFile.ReadLine();
                while (currLine != null)
                {
                    result1.Add(currLine);
                    currLine = readerFirsFile.ReadLine();
                }

            }
            using (var readerSecondFile = new StreamReader(Path.Combine(pathFolder, secondFile)))
            {
                string currLine = readerSecondFile.ReadLine();

                while (currLine!= null)
                {
                    result2.Add(currLine);
                    currLine = readerSecondFile.ReadLine();
                }
               
            }

            using (var writer=new StreamWriter(Path.Combine(pathFolder,outputFile)))
            {
                for (int i = 0; i < result1.Count; i++)
                {
                    writer.WriteLine(result1[i]);
                    writer.WriteLine(result2[i]);
                }
            }

        }
    }
}
