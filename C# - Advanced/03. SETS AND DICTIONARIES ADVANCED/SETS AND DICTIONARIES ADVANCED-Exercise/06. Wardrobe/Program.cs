using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> clothes
                = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] currLine = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string color = currLine[0];

                string[] dress = currLine[1]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (!clothes.ContainsKey(color))
                {
                    clothes.Add(color, new Dictionary<string, int>());
                }

                if (clothes.ContainsKey(color))
                {
                    foreach (var item in dress)
                    {
                        if (!clothes[color].ContainsKey(item))
                        {
                            clothes[color].Add(item, 1);
                        }
                        else
                        {
                            clothes[color][item]++;
                        }
                    }
                }
            }

            string[] clothesToFind = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string colorToFind = clothesToFind[0];
            string clothToFind = clothesToFind[1];


            foreach (var kvp in clothes)
            {
                Console.WriteLine($"{kvp.Key} clothes:");
                foreach (var item in kvp.Value)
                {
                    if (kvp.Key == colorToFind && item.Key ==clothToFind)
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                    
                }
            }


        }
    }
}
