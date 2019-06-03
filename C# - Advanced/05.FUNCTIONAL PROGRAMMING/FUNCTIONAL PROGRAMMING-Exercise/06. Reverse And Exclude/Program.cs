using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<List<int>> printNumber = numbers => Console.WriteLine(string.Join(" ", numbers));
            List<int> result = new List<int>();
            Func<List<int>, List<int>> reversedNumber = numbers =>
                 {
                     for (int i = numbers.Count - 1; i >= 0; i--)
                     {
                         result.Add(numbers[i]);
                     }
                     return result;
                 };


            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int devisibleNumber = int.Parse(Console.ReadLine());

            Predicate<int> isNotDevisible = number => number % devisibleNumber != 0;

            input = input.Where(x => isNotDevisible(x)).ToList();

            reversedNumber(input);
            printNumber(result);

        }
    }
}
