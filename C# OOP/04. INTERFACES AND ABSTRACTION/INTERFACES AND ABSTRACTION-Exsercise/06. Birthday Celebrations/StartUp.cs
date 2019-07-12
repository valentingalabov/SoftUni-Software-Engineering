using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<IBirthdate> birthdates = new List<IBirthdate>();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split();

                string type = tokens[0];
                if (type == "Citizen")
                {
                    birthdates.Add(new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]));
                }

                else if (type == "Pet")
                {
                    birthdates.Add(new Pet(tokens[1], tokens[2]));

                }
            }

            string year = Console.ReadLine();

            birthdates.Where(b => b.Birthdate.EndsWith(year))
                .Select(b => b.Birthdate)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
