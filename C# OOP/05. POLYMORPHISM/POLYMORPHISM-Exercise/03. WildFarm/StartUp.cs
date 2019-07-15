using System;
using System.Collections.Generic;
using WildFarm.Models.Animals;
using WildFarm.Models.Foods;

namespace WildFarm
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Animal> animals = new List<Animal>();

            while (input != "End")
            {
                string[] animalArgs = input.Split();

                Animal animal = AnimalFactory.Create(animalArgs);

                string[] foodArg = Console.ReadLine().Split();

                Food food = FoodFactory.Create(foodArg);

                Console.WriteLine(animal.ProduceSount());

                try
                {
                    animal.Eat(food);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

                animals.Add(animal);

                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }


        }
    }
}
