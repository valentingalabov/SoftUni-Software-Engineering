using System;
using System.Collections.Generic;
using System.Text;

namespace FightingArena
{
    public class Gladiator
    {
        //        •	Name: string
        //•	Stat: Stat
        //•	Weapon: Weapon
        //•	GetTotalPower() : int – return the sum of the stat properties plus the sum of the weapon properties.
        //•	GetWeaponPower() : int - return the sum of the weapon properties.
        // •	GetStatPower(): int - return the sum of the stat properties.

        public Gladiator(string name, Stat stat, Weapon weapon)
        {
            Name = name;
            Stat = stat;
            Weapon = weapon;
        }


        public string Name { get; set; }

        public Stat Stat { get; set; }

        public Weapon Weapon { get; set; }

        public int GetTotalPower()
        {
            int sumOfStatProp = Stat.Agility + Stat.Flexibility + Stat.Intelligence + Stat.Skills + Stat.Strength;
            int sumOfWeaponProp = Weapon.Sharpness + Weapon.Size + Weapon.Solidity;
            return sumOfStatProp + sumOfWeaponProp;
        }

        public int GetWeaponPower()
        {
            return Weapon.Sharpness + Weapon.Size + Weapon.Solidity;
        }

        public int GetStatPower()
        {
            return Stat.Agility + Stat.Flexibility + Stat.Intelligence + Stat.Skills + Stat.Strength; ;
        }

        public override string ToString()
        {
            return $@"{Name} - {GetTotalPower()}
Weapon Power: {GetWeaponPower()}
Stat Power: {GetStatPower()}";
        }

    }

}
