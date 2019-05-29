using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathFolder = "files";
            string textFile = "text.txt";
            string wordsFile = "words.txt";

            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            using (var readerForWords = new StreamReader(Path.Combine(pathFolder, wordsFile)))
            {
                string[] line = readerForWords.ReadLine().Split(" ").ToArray();
                for (int i = 0; i < line.Length; i++)
                {
                    if (!wordsCount.ContainsKey(line[i].ToLower()))
                    {
                        wordsCount.Add(line[i].ToLower(), 0);
                    }

                }
            }
            using (var readerForText = new StreamReader(Path.Combine(pathFolder, textFile)))
            {
                char[] separators = { ' ', ',', '-', '.' };
                string text = readerForText.ReadLine();
                while (text != null)
                {
                    string[] currLine = text.Split(separators).ToArray();
                    for (int i = 0; i < currLine.Length; i++)
                    {
                        string currWord = currLine[i].ToLower();

                        if (wordsCount.ContainsKey(currWord))
                        {
                            wordsCount[currWord]++;
                        }


                    }
                    text = readerForText.ReadLine();
                }

               
            }
            string output = "Output.txt";
            using (var writer = new StreamWriter(Path.Combine(pathFolder, output)))
            {
                foreach (var kvp in wordsCount.OrderByDescending(x => x.Value))
                {
                    writer.WriteLine($"{kvp.Key} - {kvp.Value}");
                }


            }



        }
    }
}