﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes
{
    public class Hero
    {
        public Hero(string name, int level, Item item)
        {
            Name = name;
            Level = level;
            Item = item;
        }

        public string Name { get; set; }

        public int Level { get; set; }

        public Item Item { get; set; }

        public override string ToString()
        {
            return $@"Hero: {Name} – {Level}lvl
Item:
  * Strength: {Item.Strength}
  * Ability: {Item.Ability}
  * Intelligence: {Item.Intelligence}";
        }


    }
}
