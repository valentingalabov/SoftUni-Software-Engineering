using System;
using System.Collections.Generic;

namespace _01._Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfEntries = int.Parse(Console.ReadLine());

            HashSet<string> usernames = new HashSet<string>();

            for (int i = 0; i < numberOfEntries; i++)
            {
                string user = Console.ReadLine();
                usernames.Add(user);
            }

            foreach (var user in usernames)
            {
                Console.WriteLine(user);
            }



        }
    }
}
