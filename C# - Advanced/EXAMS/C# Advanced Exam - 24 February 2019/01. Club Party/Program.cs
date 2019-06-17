using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Club_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int hallsMaxCapacity = int.Parse(Console.ReadLine());

            var hallsWithReservation = new Dictionary<string, List<int>>();

            var halls = new Queue<string>();



            Stack<string> input = new Stack<string>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries));


            while (input.Any())
            {
                var currentChar = input.Peek();

                if (!char.IsDigit(currentChar[0]))
                {
                    hallsWithReservation[currentChar] = new List<int>();
                    halls.Enqueue(currentChar);
                    input.Pop();
                    continue;
                }
                if (hallsWithReservation.Count == 0)
                {
                    input.Pop();
                    continue;
                }

                foreach (var hall in hallsWithReservation)
                {
                    if (hall.Value.Sum() + int.Parse(currentChar) <= hallsMaxCapacity && halls.Any())
                    {
                        hallsWithReservation[hall.Key].Add(int.Parse(currentChar));
                        input.Pop();
                        break;
                    }
                    if (hall.Value.Sum() + int.Parse(currentChar) >= hallsMaxCapacity && halls.Any())
                    {
                        Console.WriteLine($"{halls.Dequeue()} -> {string.Join(", ", hall.Value)}");
                        hallsWithReservation.Remove(hall.Key);
                    }

                    break;

                }
            }


        }
    }
}
