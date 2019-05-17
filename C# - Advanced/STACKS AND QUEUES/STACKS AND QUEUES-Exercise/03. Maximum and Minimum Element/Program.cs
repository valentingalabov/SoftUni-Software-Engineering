using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            List<int> result = new List<int>();
            for (int i = 0; i < numberOfLines; i++)
            {
                int[] currentLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (currentLine[0] == 1)
                {
                    stack.Push(currentLine[1]);
                }
                else if (currentLine[0] == 2 && stack.Count > 0)
                {
                    stack.Pop();
                }
                else if (currentLine[0] == 3 && stack.Count > 0)
                {

                    result.Add(stack.Max());
                }
                else if (currentLine[0] == 4 && stack.Count > 0)
                {
                    result.Add(stack.Min());
                }
            }
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(string.Join(", ", stack));

        }
    }
}
