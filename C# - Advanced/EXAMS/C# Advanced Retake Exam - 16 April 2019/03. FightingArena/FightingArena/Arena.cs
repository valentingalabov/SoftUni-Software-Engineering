using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightingArena
{
    public class Arena
    {
        private List<Gladiator> gladiators;



        public Arena(string name)
        {
            Name = name;
            this.gladiators = new List<Gladiator>();
        }


        public string Name { get; set; }
        public int Count => gladiators.Count;

        public void Add(Gladiator gladiator)
        {
            gladiators.Add(gladiator);
        }

        public void Remove(string name)
        {
            var gladiatorTORemove = gladiators.FirstOrDefault(x => x.Name == name);
            gladiators.Remove(gladiatorTORemove);

        }
        public Gladiator GetGladitorWithHighestStatPower()
        {
            int maxGladiatorPower = int.MinValue;

            foreach (var gladiator in gladiators)
            {
                if (maxGladiatorPower < gladiator.GetStatPower())
                {
                    maxGladiatorPower = gladiator.GetStatPower();
                }
            }

            var currentGladiator = gladiators.FirstOrDefault(x => x.GetStatPower() == maxGladiatorPower);
            return currentGladiator;
        }

        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            int maxWeaponPower = int.MinValue;
            foreach (var gladiator in gladiators)
            {
                if (maxWeaponPower < gladiator.GetWeaponPower())
                {
                    maxWeaponPower = gladiator.GetWeaponPower();
                }
            }

            var currentWeaponPower = gladiators.FirstOrDefault(x => x.GetWeaponPower() == maxWeaponPower);

            return currentWeaponPower;
        }

        public Gladiator GetGladitorWithHighestTotalPower()
        {
            int maxTotalPower = int.MinValue;
            foreach (var gladiator in gladiators)
            {
                if (maxTotalPower < gladiator.GetTotalPower())
                {
                    maxTotalPower = gladiator.GetTotalPower();
                }
            }

            var currentTotalPower = gladiators.FirstOrDefault(x => x.GetTotalPower() == maxTotalPower);

            return currentTotalPower;
        }

        public override string ToString()
        {
            return $"[{this.Name}] - [{this.Count}] gladiators are participating.";
        }
    }
}
