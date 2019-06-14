using System;

namespace GenericCountMethodString
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Box<string> box = new Box<string>();

            int numberOfElementsToAdd = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfElementsToAdd; i++)
            {
                string currenElement = Console.ReadLine();
                box.Add(currenElement);
            }

            string valueToCoparison = Console.ReadLine();

            box.Compare(valueToCoparison);

        }
    }
}
