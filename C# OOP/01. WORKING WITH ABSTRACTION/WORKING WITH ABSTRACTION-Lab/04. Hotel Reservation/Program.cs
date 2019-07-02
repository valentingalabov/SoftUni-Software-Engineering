using System;

namespace _04._Hotel_Reservation
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
            .Split();
            var priceCalculator = new PriceCalculator(input);

            Console.WriteLine(priceCalculator.GetTotalPrice().ToString("F2"));
        }
    }
}
