using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfInput = int.Parse(Console.ReadLine());
            SortedSet<string> chemicalCompounds = new SortedSet<string>();

            for (int i = 0; i < countOfInput; i++)
            {
                string[] currCopounds = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                foreach (var item in currCopounds)
                {
                    chemicalCompounds.Add(item);
                }

            }

            Console.WriteLine(string.Join(" ",chemicalCompounds));

        }
    }
}
