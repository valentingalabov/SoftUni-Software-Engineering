using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int numberOfElementToPush = firstLine[0];
            int elementToPop = firstLine[1];
            int elementToSearch = firstLine[2];
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < numberOfElementToPush; i++)
            {
                stack.Push(numbers[i]);
            }
            for (int i = 0; i < elementToPop; i++)
            {
                stack.Pop();
            }
            if (stack.Contains(elementToSearch))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (stack.Count == 0)
                {
                    Console.WriteLine("0");
                }
                else
                {
                    Console.WriteLine(stack.Min());
                }
            }
        }
    }
}
