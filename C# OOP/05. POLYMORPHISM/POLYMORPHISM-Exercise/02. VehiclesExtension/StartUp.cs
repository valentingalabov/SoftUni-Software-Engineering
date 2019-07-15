using System;
using System.Linq;

namespace VehiclesExtension
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            Vehicle car = new Car(double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3]));

            input = Console.ReadLine().Split();

            Vehicle truck = new Truck(double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3]));

            input = Console.ReadLine().Split();

            Vehicle bus = new Bus(double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3]));

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
                else if (type is nameof(Bus))
                {
                    ExecuteCommand(bus, command, value);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);

        }

        private static void ExecuteCommand(Vehicle vehicle, string command, double value)
        {
            if (command == "Drive")
            {
                Console.WriteLine(vehicle.Drive(value));
            }
            else if (command == "Refuel")
            {
                try
                {
                    vehicle.Refuel(value);
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            else if (command == "DriveEmpty")
            {
                ((Bus)vehicle).SwitchOffAirConditioner();
                Console.WriteLine(vehicle.Drive(value));
                ((Bus)vehicle).SwitchOnAirConditioner();


            }
        }
    }
}
