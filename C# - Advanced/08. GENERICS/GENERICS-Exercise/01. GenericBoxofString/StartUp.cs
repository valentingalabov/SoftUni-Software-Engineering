using System;

namespace GenericBoxofString
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Box<string> myBox = new Box<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                 var currentInput = Console.ReadLine();


                myBox.Add(currentInput);

            }

            Console.WriteLine(myBox.ToString().TrimEnd());

        }
    }
}
