using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Birds
{
    public class Hen : Bird
    {
        private const double GainValue = 0.35;

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(Food food)
        {
            this.BaseEat(food, new List<string>() { nameof(Meat), nameof(Fruit), nameof(Vegetable), nameof(Seeds) }, GainValue);
        }

        public override string ProduceSount()
        {
            return "Cluck";
        }
    }
}
