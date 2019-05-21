﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> counter = new Dictionary<double, int>();
            foreach (var number in numbers)
            {
                if (counter.ContainsKey(number))
                {
                    counter[number]++;
                }
                else
                {
                    counter.Add(number, 1);
                }
            }
            foreach (var item in counter)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
