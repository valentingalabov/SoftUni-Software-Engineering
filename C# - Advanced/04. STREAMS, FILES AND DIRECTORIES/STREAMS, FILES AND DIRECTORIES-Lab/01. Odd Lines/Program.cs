using System;
using System.IO;

namespace _01._Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "Files";
            string file = "Input.txt";
            string outputFile = "Output.txt";
            string filePath = Path.Combine(path, file);
            using (var reader = new StreamReader(filePath))
            {
                int count = 0;

                string line = reader.ReadLine();

                using (var writer = new StreamWriter(Path.Combine(path, outputFile)))
                {


                    while (line != null)
                    {
                        if (count % 2 != 0)
                        {
                            writer.WriteLine(line);
                        }

                        count++;
                        line = reader.ReadLine();
                    }
                }
                
            }



        }
    }
}
