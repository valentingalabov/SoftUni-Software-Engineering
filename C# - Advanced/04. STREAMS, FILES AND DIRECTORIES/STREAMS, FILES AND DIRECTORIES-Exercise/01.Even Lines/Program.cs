using System;
using System.IO;
using System.Linq;

namespace _01.Even_Lines_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string textFilePath = @"text.txt";

            int counter = 0;

            using (StreamReader streamReader = new StreamReader(textFilePath))
            {
                string currentLine = streamReader.ReadLine();

                while (currentLine != null)
                {
                    if (counter % 2 == 0)
                    {
                        string replacedSymbols = ReplaceSpecialCharacters(currentLine);
                        string ReversedWords = ReverseWords(replacedSymbols);

                        Console.WriteLine(ReversedWords);
                    }

                    

                    currentLine = streamReader.ReadLine();

                    counter++;
                }
            }

        }

        private static string ReverseWords(string replacedSymbols)
        {
            return string.Join(" ",replacedSymbols.Split(" ").Reverse());
        }

        private static string ReplaceSpecialCharacters(string currentLine)
        {
            return currentLine.Replace(oldValue: "-", newValue: "@")
            .Replace(oldValue: ",", newValue: "@")
            .Replace(oldValue: ".", newValue: "@")
            .Replace(oldValue: "!", newValue: "@")
            .Replace(oldValue: "?", newValue: "@");
        }
    }
}
