using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int firstSetLenght = numbers[0];
            int secondSetLenght = numbers[1];

            List<int> firstSet = new List<int>();
            List<int> secondSet = new List<int>();

            HashSet<int> result = new HashSet<int>();

            for (int i = 0; i < firstSetLenght; i++)
            {
                int currElement = int.Parse(Console.ReadLine());
                firstSet.Add(currElement);
            }

            for (int i = 0; i < secondSetLenght; i++)
            {
                int currElement = int.Parse(Console.ReadLine());
                secondSet.Add(currElement);
            }

            for (int i = 0; i < firstSetLenght; i++)
            {
                for (int j = 0; j < secondSetLenght; j++)
                {
                    if (firstSet[i]==secondSet[j])
                    {
                        result.Add(firstSet[i]);
                    }
                }
            }

            Console.WriteLine(string.Join(" ",result));

        }
    }
}
