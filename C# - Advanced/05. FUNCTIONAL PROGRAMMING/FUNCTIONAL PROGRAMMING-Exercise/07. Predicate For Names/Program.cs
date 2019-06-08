using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<List<string>> printNames = name => Console.WriteLine(string.Join(Environment.NewLine,name));

            int lenght = int.Parse(Console.ReadLine());

            var names = Console.ReadLine()
                .Split()
                .ToList();

            Predicate<string> isValidNames = name => name.Length <= lenght;
            names = names
                .Where(x => isValidNames(x))
                .ToList();

            printNames(names);
        }
    }
}
