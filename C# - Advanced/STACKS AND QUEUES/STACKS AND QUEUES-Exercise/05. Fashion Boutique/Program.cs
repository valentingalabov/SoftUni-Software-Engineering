using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var clothes = new Stack<int>(input);
            int totalracks = 1;
            int rackCapacity = int.Parse(Console.ReadLine());
            int totalcapacity = rackCapacity;
            if (clothes.Count == 0)
            {
                Console.WriteLine($"0");
            }
            while (clothes.Any())
            {
                int currentcloth = clothes.Pop();

                if (rackCapacity - currentcloth == 0)
                {
                    rackCapacity -= currentcloth;
                    rackCapacity = totalcapacity;
                    if (clothes.Count > 0)
                    {
                        totalracks++;
                    }

                }
                else if (rackCapacity - currentcloth < 0)
                {
                    totalracks++;
                    rackCapacity = totalcapacity;
                    rackCapacity -= currentcloth;
                }
                else if (rackCapacity - currentcloth > 0)
                {
                    rackCapacity -= currentcloth;
                }

            }
            Console.WriteLine(totalracks);
        }
    }
}
