using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());

            var cars = new Queue<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] data = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);


                //"{model} {engineSpeed} {enginePower} {cargoWeight} {cargoType} {tire1Pressure} {tire1Age} {tire2Pressure} {tire2Age} {tire3Pressure} {tire3Age} {tire4Pressure} {tire4Age}"//

                string model = data[0];

                int engineSpeed = int.Parse(data[1]);
                int enginePower = int.Parse(data[2]);

                int cargoWeight = int.Parse(data[3]);
                string cargoType = data[4];

                double tire1Pressure = double.Parse(data[5]);
                int tire1Age = int.Parse(data[6]);

                double tire2Pressure = double.Parse(data[7]);
                int tire2Age = int.Parse(data[8]);

                double tire3Pressure = double.Parse(data[9]);
                int tire3Age = int.Parse(data[10]);

                double tire4Pressure = double.Parse(data[11]);
                int tire4Age = int.Parse(data[12]);



                Car car = new Car(model, new Engine(engineSpeed, enginePower), new Cargo(cargoWeight, cargoType),
                   new Tire[4]
                   {
                       new Tire(tire1Age,tire1Pressure),
                        new Tire(tire2Age,tire2Pressure),
                        new Tire(tire3Age,tire3Pressure),
                         new Tire(tire4Age,tire4Pressure)
                   });

                cars.Enqueue(car);

            }
            string command = Console.ReadLine();

            if (command== "fragile")
            {
                var sorted = cars.Where(c => c.Cargo.Type == command)
                    .Where(t => t.Tires.Where(f => f.Preshure < 1)
                    .FirstOrDefault() != null).Select(x=>x.Model);
                Console.WriteLine(string.Join(Environment.NewLine, sorted));

            }
            else if(command== "flamable")
            {
                var sorted = cars.Where(c => c.Cargo.Type == command)
                    .Where(e => e.Engine.Power > 250).Select(c=>c.Model) ;
                Console.WriteLine(string.Join(Environment.NewLine, sorted));
            }

            //Console.WriteLine(string.Join(Environment.NewLine, cars
            //             .Where(c => c.Cargo.Type == command && command == "fragile"
            //                 ? c.Tires
            //                     .Where(t => t.Preshure < 1)
            //                     .FirstOrDefault() != null
            //                 : c.Engine.Power > 250)
            //             .Select(c => c.Model)));
        }
    }
}