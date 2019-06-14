using System;

namespace GenericBoxofinteger
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Box<int> myBox = new Box<int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int currentInput =int.Parse(Console.ReadLine());

                myBox.Add(currentInput);
            }

            Console.WriteLine(myBox.ToString().TrimEnd());

        }
    }
}
