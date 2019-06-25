using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStationRecruitment
{
    public class SpaceStation
    {
        private List<Astronaut> data;

        public SpaceStation(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;

            data = new List<Astronaut>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }


        public int Count => data.Count;

        public void Add(Astronaut astronaut)
        {
            if (data.Count <= Capacity)
            {
                data.Add(astronaut);
            }
        }




        public bool Remove(string name)
        {
            var findIt = data.FirstOrDefault(n => n.Name == name);

            if (data.Contains(findIt))
            {
                data.Remove(findIt);
                return true;
            }
            return false;
        }

        public Astronaut GetOldestAstronaut()
        {
            int highestAge = int.MinValue;

            foreach (var item in data)
            {
                if (item.Age > highestAge)
                {
                    highestAge = item.Age;
                }
            }

            var oldestAstronaut = data.FirstOrDefault(a => a.Age == highestAge);

            return oldestAstronaut;
        }

        public Astronaut GetAstronaut(string name)
        {
            var astronautWithGivenName = data.FirstOrDefault(n => n.Name == name);
            return astronautWithGivenName;
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Astronauts working at Space Station {this.Name}:");

            foreach (var currentAstronaut in data)
            {
                result.AppendLine(currentAstronaut.ToString());
            }

            return result.ToString().TrimEnd();
        }



    }
}
