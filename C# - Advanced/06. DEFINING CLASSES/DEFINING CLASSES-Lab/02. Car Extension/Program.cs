
using System;

namespace _02._Car_Extension
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            car.Make = "VW";
            car.Model = "MK3";
            car.Year = 1992;
            car.FuelQuantity = 22;
            car.FuelConsumption =10;
            car.Drive(200.00);

            Console.WriteLine(car.WhoAmI());

        }
    }
}
