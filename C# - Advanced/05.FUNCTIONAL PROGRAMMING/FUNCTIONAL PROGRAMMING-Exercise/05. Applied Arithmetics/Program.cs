using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<int[]> printNum = number =>
               Console.WriteLine(string.Join(" ", number));

            var inputNumber = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Func<int, int> incrementsByOne = x => x += 1;
            Func<int, int> substractByOne = x => x -= 1;
            Func<int, int> multipay = x => x *2;

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "print")
                {
                    printNum(inputNumber);
                }
                else if (command == "add")
                {
                   inputNumber= inputNumber.Select(x => incrementsByOne(x)).ToArray();

                }
                else if (command == "multiply")
                {
                    inputNumber = inputNumber.Select(x => multipay(x)).ToArray();
                }
                else if (command == "subtract")
                {
                    inputNumber = inputNumber.Select(x => substractByOne(x)).ToArray();
                }

            }

        }
    }
}
