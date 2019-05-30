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

            string textPath = "text.txt";
            string wordsPath = "words.txt";

            string[] textLines = File.ReadAllLines(textPath);
            string[] words = File.ReadAllLines(wordsPath);

            var wordsInfo = new Dictionary<string, int>();

            foreach (var word in words)
            {

                string currentWordToLowerCase = word.ToLower();

                if (!wordsInfo.ContainsKey(currentWordToLowerCase))
                {
                    wordsInfo.Add(word, 0);
                }
            }

            foreach (var currenLine in textLines)
            {
                string[] currentLineWords = currenLine.Split(new char[] { ' ', ',', '?', '!', '.', ':', ';', '-' });
                foreach (var item in currentLineWords)
                {
                    if (wordsInfo.ContainsKey(item.ToLower()))
                    {
                        wordsInfo[item.ToLower()]++;
                    }
                }
            }

            string actualResultPath = "actualResult.txt";
            string expectedResultPath = "expectedResult.txt";

            foreach (var kvp in wordsInfo)
            {
                File.AppendAllText(actualResultPath,$"{kvp.Key} - {kvp.Value}{ Environment.NewLine}");
            }
            foreach (var kvp in wordsInfo.OrderByDescending(x=>x.Value))
            {
                File.AppendAllText(expectedResultPath, $"{kvp.Key} - {kvp.Value}{ Environment.NewLine}");
            }

        }
    }
}
