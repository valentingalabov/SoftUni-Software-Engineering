using System;

namespace Template_Pattern
{
    public class Sourdough : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking tge Sourdough Bread. (20 minutes)");
        }

        public override void MixIngradients()
        {
            Console.WriteLine("Gethering Ingredients for Sourdough Bread.");
        }
    }
}
