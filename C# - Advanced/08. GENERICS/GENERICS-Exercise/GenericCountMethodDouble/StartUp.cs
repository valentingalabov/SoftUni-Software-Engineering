using System;

namespace GenericCountMethodDouble
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Box<double> box = new Box<double>();

            double numberOfElementsToAdd = double.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfElementsToAdd; i++)
            {
                double currenElement = double.Parse(Console.ReadLine());
                box.Add(currenElement);
            }

            double valueToCoparison = double.Parse(Console.ReadLine());

            box.Compare(valueToCoparison);
        }
    }
}
