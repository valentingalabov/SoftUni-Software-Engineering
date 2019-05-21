using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Cities_by_Continent
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> continents
                = new Dictionary<string, Dictionary<string, List<string>>>();

            int numberOfRecords = int.Parse(Console.ReadLine());



            for (int i = 0; i < numberOfRecords; i++)
            {
                var entry = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (!continents.ContainsKey(entry[0]))
                {
                    continents.Add(entry[0], new Dictionary<string, List<string>>());

                }
                if (!continents[entry[0]].ContainsKey(entry[1]))
                {
                    continents[entry[0]].Add(entry[1], new List<string>());
                }

                continents[entry[0]][entry[1]].Add(entry[2]);



            }

            foreach (var contitent in continents)
            {
                Console.WriteLine($"{contitent.Key}:");
                foreach (var item in contitent.Value)
                {
                    Console.WriteLine($"{item.Key} -> {string.Join(", ", item.Value)}");
                }


            }

        }
    }
}
