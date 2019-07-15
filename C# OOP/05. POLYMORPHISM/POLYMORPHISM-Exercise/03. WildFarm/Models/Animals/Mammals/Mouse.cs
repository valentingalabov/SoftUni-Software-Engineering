using System;
using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Mammals
{
    public class Mouse : Mammal
    {
        private const double GainValue = 0.10;


        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat(Food food)
        {

            this.BaseEat(food, new List<string>() { nameof(Vegetable), nameof(Fruit) }, GainValue);
        }


        public override string ProduceSount()
        {
            return "Squeak";
        }
    }
}
