using System;
using System.Collections.Generic;

namespace _05._Record_Unique_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int nameCount = int.Parse(Console.ReadLine());

            HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < nameCount; i++)
            {
                var entry = Console.ReadLine();
                names.Add(entry);
            }
            foreach (var item in names)
            {
                Console.WriteLine(item);
            }

        }
    }
}
