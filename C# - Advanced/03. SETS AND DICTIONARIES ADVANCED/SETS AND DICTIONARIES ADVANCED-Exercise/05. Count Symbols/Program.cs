using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray();
            SortedDictionary<char, int> occurrences = new SortedDictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!occurrences.ContainsKey(input[i]))
                {
                    occurrences.Add(input[i], 1);
                }
                else
                {
                    occurrences[input[i]]++;
                }
            }

            foreach (var kvp in occurrences)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }

        }
    }
}
