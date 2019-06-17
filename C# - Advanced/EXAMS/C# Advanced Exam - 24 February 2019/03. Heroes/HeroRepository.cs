using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> heroes;

        public HeroRepository()
        {
            heroes = new List<Hero>();
        }

        public int Count => heroes.Count;

        public void Add(Hero hero)
        {
            heroes.Add(hero);
        }

        public void Remove(string name)
        {
            var currentHero = heroes.FirstOrDefault(x => x.Name == name);
            heroes.Remove(currentHero);
        }

        public Hero GetHeroWithHighestStrength()
        {
            int maxStrength = int.MinValue;
             
            foreach (var hero in heroes)
            {
                if (hero.Item.Strength>maxStrength)
                {
                    maxStrength = hero.Item.Strength;
                }
            }
            var heroWithMaxStr = heroes.FirstOrDefault(x => x.Item.Strength == maxStrength);
            return heroWithMaxStr;
        }

        public Hero GetHeroWithHighestAbility()
        {
            int maxAbility = int.MinValue;

            foreach (var hero in heroes)
            {
                if (hero.Item.Ability > maxAbility)
                {
                    maxAbility = hero.Item.Ability;
                }
            }
            var heroWithMaxAbility = heroes.FirstOrDefault(x => x.Item.Ability == maxAbility);
            return heroWithMaxAbility;
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            int maxIntelligence = int.MinValue;

            foreach (var hero in heroes)
            {
                if (hero.Item.Intelligence > maxIntelligence)
                {
                    maxIntelligence = hero.Item.Intelligence;
                }
            }
            var heroWithMaxInt = heroes.FirstOrDefault(x => x.Item.Intelligence == maxIntelligence);
            return heroWithMaxInt;
        }

        public override string ToString()
        {
            var repositoryInfo = new StringBuilder();

            foreach (var hero in heroes)
            {
                repositoryInfo.Append(hero);
            }
            return repositoryInfo.ToString();
        }
    }
}
