using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Special_Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            while ((input = Console.ReadLine()) != "No more tires")
            {
                string[] tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var currentTires = new Tire[4]
                {
                    new Tire(int.Parse(tokens[0]), double.Parse(tokens[1])),
                    new Tire(int.Parse(tokens[2]), double.Parse(tokens[3])),
                    new Tire(int.Parse(tokens[4]), double.Parse(tokens[5])),
                    new Tire(int.Parse(tokens[6]), double.Parse(tokens[7])),
                };

                tires.Add(currentTires);


            }

            while ((input = Console.ReadLine()) != "Engines done")
            {
                string[] tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int horsePower = int.Parse(tokens[0]);
                double cubicCapacity = double.Parse(tokens[1]);

                var engine = new Engine(horsePower, cubicCapacity);

                engines.Add(engine);


            }
            while ((input = Console.ReadLine()) != "Show special")
            {
                string[] tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);


                var car = new Car
                    (
                    tokens[0],
                    tokens[1],
                    int.Parse(tokens[2]),
                    double.Parse(tokens[3]),
                    double.Parse(tokens[4]),
                    engines[int.Parse(tokens[5])],
                    tires[int.Parse(tokens[6])]

                );

                cars.Add(car);
            }

            var filteredCars = cars
                .Where(x => x.Year >= 2017)
                .Where(x => x.Engine.HorsePower > 300)
                .Where(x => x.Tires.Sum(y => y.Pressure) >= 9 && x.Tires.Sum(y => y.Pressure) <= 10)
                .ToList();

            foreach (var car in filteredCars)
            {
                car.Drive(20);
            }

            foreach (var car in filteredCars)
            {
                Console.WriteLine($"Make: {car.Make}");
                Console.WriteLine($"Model: {car.Model}");
                Console.WriteLine($"Year: {car.Year}");
                Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
            }
        }
    }
}
