using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> familyMembers;

        public Family()
        {
            familyMembers = new List<Person>();
        }

        public void AddMember(Person member)
        {
            familyMembers.Add(member);
        }


        public void  sortedMember()
        {
            var oldestPerson = familyMembers.OrderBy(p => p.Name).Where(p => p.Age > 30).ToArray();

            foreach (var item in oldestPerson)
            {
                Console.WriteLine($"{item.Name} - {item.Age}");
            }
        }


    }
}
