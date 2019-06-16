using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Trojan_Invasion
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> plates = new List<int>();
            var warriors = new Stack<int>();

            int numberOfWaves = int.Parse(Console.ReadLine());

            int[] platesOfSpartanDefense = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            foreach (var item in platesOfSpartanDefense)
            {
                plates.Add(item);
            }


            for (int i = 1; i <= numberOfWaves; i++)
            {
                if (!plates.Any())
                {
                    break;
                }

                warriors = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

                if (i % 3 == 0)
                {
                    plates.Add(int.Parse(Console.ReadLine()));
                }

                while (warriors.Any() && plates.Any())
                {

                    var currWarrior = warriors.Peek();
                    var currPlate = plates[0];

                    if (currWarrior < currPlate)
                    {
                        warriors.Pop();
                        plates[0] -= currWarrior;
                    }
                    else if (currWarrior > currPlate)
                    {
                        plates.RemoveAt(0);
                        warriors.Pop();
                        warriors.Push(currWarrior - currPlate);
                    }
                    else
                    {
                        plates.RemoveAt(0);
                        warriors.Pop();
                    }


                }





            }


            if (plates.Any())
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine("Plates left: " + string.Join(", ", plates));
            }
            else
            {
                Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
                Console.WriteLine("Warriors left: " + string.Join(", ", warriors));
            }




        }
    }
}
