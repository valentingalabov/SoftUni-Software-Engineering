using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine().Split().ToArray();
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int elementsToAdd = int.Parse(firstLine[0]);
            int elementToRemove = int.Parse(firstLine[1]);
            int elementToSearch = int.Parse(firstLine[2]);
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < elementsToAdd; i++)
            {
                queue.Enqueue(numbers[i]);
            }
            for (int i = 0; i < elementToRemove; i++)
            {
                queue.Dequeue();
            }
            if (queue.Count==0)
            {
                Console.WriteLine("0");
            }
            else if (queue.Contains(elementToSearch))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
