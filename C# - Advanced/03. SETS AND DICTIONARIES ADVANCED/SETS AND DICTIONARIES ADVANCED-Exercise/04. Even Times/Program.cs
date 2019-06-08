using System;
using System.Collections.Generic;

namespace _04._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfInt = int.Parse(Console.ReadLine());
            Dictionary<int, int> numbers = new Dictionary<int, int>();
            for (int i = 0; i < countOfInt; i++)
            {
                int currLine = int.Parse(Console.ReadLine());
                if (!numbers.ContainsKey(currLine))
                {
                    numbers.Add(currLine,1);
                }
                else
                {
                    numbers[currLine]++;
                }

            }
            foreach (var kvp in numbers)
            {
                if (kvp.Value%2==0)
                {
                    Console.WriteLine(kvp.Key);
                }
            }



        }
    }
}
