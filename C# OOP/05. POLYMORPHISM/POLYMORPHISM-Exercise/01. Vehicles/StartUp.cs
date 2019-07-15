using System;
using System.Linq;

namespace Vehicles
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine()
                .Split()
                .ToArray();

            Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));

            string[] truckInfo = Console.ReadLine()
                .Split()
                .ToArray();

            Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] currentCommand = Console.ReadLine().Split();

                string type = currentCommand[1];
                string command = currentCommand[0];
                double value = double.Parse(currentCommand[2]);

                if (type is nameof(Car))
                {
                    ExecuteCommand(car, command, value);
                }
                else if (type is nameof(Truck))
                {
                    ExecuteCommand(truck, command, value);
                }

            }

            Console.WriteLine(car);
            Console.WriteLine(truck);

        }

        private static void ExecuteCommand(Vehicle vehicle, string command, double value)
        {
            if (command == "Drive")
            {
                Console.WriteLine(vehicle.Drive(value));
            }
            else if (command == "Refuel")
            {
                vehicle.Refuel(value);
            }
        }
    }
}
