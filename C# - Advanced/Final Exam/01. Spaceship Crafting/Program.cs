using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Spaceship_Crafting
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sequenceChemicalLiquids = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[] sequencePhysicalItems = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> chemicalLiquids = new Queue<int>(sequenceChemicalLiquids);
            Stack<int> physicalItems = new Stack<int>(sequencePhysicalItems);

            Dictionary<string, int> items = new Dictionary<string, int>
            {
                { "Glass", 0 },
                { "Aluminium", 0 },
                { "Lithium", 0 },
                { "Carbon fiber", 0 }
            };


            int glass = 25;
            int aluminium = 50;
            int lithium = 75;
            int carbonFiber = 100;

            while (chemicalLiquids.Any() && physicalItems.Any())
            {
                if (chemicalLiquids.Peek() + physicalItems.Peek() == glass)
                {
                    chemicalLiquids.Dequeue();
                    physicalItems.Pop();

                    items["Glass"] = +1;

                }

                else if (chemicalLiquids.Peek() + physicalItems.Peek() == aluminium)
                {
                    chemicalLiquids.Dequeue();
                    physicalItems.Pop();

                    items["Aluminium"] = +1;

                }
                else if (chemicalLiquids.Peek() + physicalItems.Peek() == lithium)
                {
                    chemicalLiquids.Dequeue();
                    physicalItems.Pop();

                    items["Lithium"] = +1;

                }
                else if (chemicalLiquids.Peek() + physicalItems.Peek() == carbonFiber)
                {
                    chemicalLiquids.Dequeue();
                    physicalItems.Pop();

                    items["Carbon fiber"] = +1;

                }



                if (chemicalLiquids.Peek() + physicalItems.Peek() != glass)
                {
                    chemicalLiquids.Dequeue();

                    int increasedValue = physicalItems.Peek() + 3;
                    physicalItems.Pop();
                    physicalItems.Push(increasedValue);

                }


            }


            int count = 0;

            foreach (var item in items)
            {
                if (item.Value > 0)
                {
                    count++;
                }
            }
            if (items.Count == count)
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            if (chemicalLiquids.Any())
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", chemicalLiquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }
            if (physicalItems.Any())
            {
                Console.WriteLine($"Physical items left: {string.Join(", ", physicalItems)}");
            }
            else
            {
                Console.WriteLine("Physical items left: none");
            }

            foreach (var item in items.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
