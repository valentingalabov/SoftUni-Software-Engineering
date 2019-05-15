using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> que = new Queue<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    que.Enqueue(numbers[i]);
                }
            }
            var result = new List<int>();
            foreach (var item in que)
            {
                result.Add(item);
            }
            Console.Write(string.Join(", ",result));
        }
    }
}
