using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<IBuyer> buyers = new List<IBuyer>();

            int numberOfPeople = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPeople; i++)
            {
                var tokens = Console.ReadLine().Split();

                if (tokens.Length == 4)
                {
                    buyers.Add(new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2], tokens[3]));
                }
                else if (tokens.Length == 3)
                {
                    buyers.Add(new Rebel(tokens[0], int.Parse(tokens[1]), tokens[2]));
                }

            }

            string name;

            while ((name = Console.ReadLine()) != "End")
            {
                var buyer = buyers.FirstOrDefault(n => n.Name == name);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }

            }

            Console.WriteLine(buyers.Sum(b => b.Food));
        }
    }
}
