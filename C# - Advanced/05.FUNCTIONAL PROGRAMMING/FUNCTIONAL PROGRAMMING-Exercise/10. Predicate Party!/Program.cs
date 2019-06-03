using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split().ToList();

            string command = string.Empty;

            List<string> namesToAdd = new List<string>();
            

            Func<string, int, bool> lengthFilter = (name, length) => name.Length == length;
            Func<string, string, bool> startWithFilter = (name, param) => name.StartsWith(param);
            Func<string, string, bool> endsWithFilter = (name, param) => name.EndsWith(param);
            Func<string, string, bool> containsFilter = (name, param) => name.Contains(param);

            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] currCommand = command.Split(" ").ToArray();
                string action = currCommand[0];
                string criteria = currCommand[1];
                string param = currCommand[2];

                if (action == "Remove")
                {

                    if (criteria == "StartsWith")
                    {
                        names = names.Where(name => !startWithFilter(name, param)).ToList();
                    }
                    else if (criteria == "EndsWith")
                    {
                        names = names.Where(name => !endsWithFilter(name, param)).ToList();
                    }
                    else if (criteria == "Length")
                    {
                        names = names.Where(name => !lengthFilter(name, int.Parse(param))).ToList();
                    }

                }
                else if (action == "Double")
                {
                    if (criteria == "StartsWith")
                    {
                        names.AddRange(names.Where(name => startWithFilter(name, param)).ToList());
                    }
                    else if (criteria == "EndsWith")
                    {
                        names.AddRange(names.Where(name => endsWithFilter(name, param)).ToList());
                    }
                    else if (criteria == "Length")
                    {
                        names.AddRange(names.Where(name => lengthFilter(name, int.Parse(param))).ToList());
                    }
                }


            }
            if (names.Count==0)
            {
                Console.WriteLine("Nobody is going to the party!");
                return;
            }
            
            Console.WriteLine(string.Join(", ", names)+ " are going to the party!");
            

        }
    }
}
