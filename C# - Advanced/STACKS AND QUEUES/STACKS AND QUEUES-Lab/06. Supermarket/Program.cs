using System;
using System.Collections.Generic;

namespace _06._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = string.Empty;
            Queue<string> queue = new Queue<string>();
            var paid = new List<string>();
            while ((line = Console.ReadLine()) != "End")
            {
                if (line != "Paid")
                {
                    queue.Enqueue(line);
                }
                else
                {
                    foreach (var people in queue)
                    {
                        paid.Add(people);
                    }
                    queue.Clear();
                }
            }
            foreach (var people in paid)
            {
                Console.WriteLine(people);
            }
            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
