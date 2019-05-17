using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityOfFood = int.Parse(Console.ReadLine());
            int[] sequence = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(sequence);
            Console.WriteLine(queue.Max());

            for (int i = 0; i < sequence.Length; i++)
            {
                if (quantityOfFood - queue.Peek() >= 0)
                {
                    quantityOfFood -= queue.Peek();
                    queue.Dequeue();

                }
            }
            if (queue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
            }

        }
    }
}
