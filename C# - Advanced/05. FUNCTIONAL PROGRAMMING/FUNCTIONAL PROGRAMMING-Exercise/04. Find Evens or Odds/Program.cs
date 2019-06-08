using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bounds = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int lowerBounds = bounds[0];
            int upperBounds = bounds[1];

            List<int> numbers = new List<int>();

            string numberType = Console.ReadLine();

            for (int i = lowerBounds; i <= upperBounds; i++)
            {
                numbers.Add(i);
            }

            Predicate<int> isEven = number => number % 2 == 0;
            Predicate<int> isOdd = number => number % 2 != 0;
            Action<List<int>> printNumbers = outputNumbers => Console.WriteLine(string.Join(" ",outputNumbers));


            if (numberType=="odd")
            {
                numbers=numbers
                    .Where(x=>isOdd(x))
                    .ToList();
            }
            else
            {
                numbers = numbers
                    .Where(x => isEven(x))
                    .ToList();
            }

            printNumbers(numbers);
        }
    }
}
