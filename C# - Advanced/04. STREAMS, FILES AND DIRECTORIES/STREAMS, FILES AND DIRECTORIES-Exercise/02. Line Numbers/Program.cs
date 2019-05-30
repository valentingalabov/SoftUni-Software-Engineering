using System;
using System.IO;
using System.Linq;

namespace _02._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string textPath = "text.txt";
            string outputPath = "output.txt";

            string[] textLines = File.ReadAllLines(textPath);

            int lineCounter = 1;

            foreach (var currentLine in textLines)
            {
                int lettersCount = currentLine.Count(char.IsLetter);
                int puncCounter = currentLine.Count(char.IsPunctuation);

                File.AppendAllText(outputPath, $"Line {lineCounter}: {currentLine}. ({lettersCount})({puncCounter}){Environment.NewLine}");

                lineCounter++;
            }

        }
    }
}
