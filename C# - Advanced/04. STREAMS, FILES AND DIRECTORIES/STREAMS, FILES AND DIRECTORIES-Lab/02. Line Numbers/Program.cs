using System;
using System.IO;

namespace _02._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "Files";
            string file = "Input.txt";
            string outputFile = "Output.txt";

            using (var reader = new StreamReader(Path.Combine(path, file)))
            {
                int count = 0;

                string line = reader.ReadLine();

                using (var writer = new StreamWriter(Path.Combine(path, outputFile)))
                {

                    while (line != null)
                    {
                        line = $"{++count}. {line}";
                        
                        writer.WriteLine(line);

                        line = reader.ReadLine();
                    }

                }
            }

        }
    }
}
