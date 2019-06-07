using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int carsCount = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < carsCount; i++)
            {
                string[] carsData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string carModel = carsData[0];
                double fuelAmount = double.Parse(carsData[1]);
                double fuelConsumptionPerKm = double.Parse(carsData[2]);

                Car car = new Car(carModel, fuelAmount, fuelConsumptionPerKm);
                cars.Add(car);

            }

            while (true)
            {
                string inputLine = Console.ReadLine();

                if (inputLine == "End")
                {
                    break;
                }

                string[] data = inputLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string carModel = data[1];
                double distance = double.Parse(data[2]);

                Car car = cars.FirstOrDefault(c => c.Model == carModel);

                car.Drive(distance);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }

        }
    }
}
