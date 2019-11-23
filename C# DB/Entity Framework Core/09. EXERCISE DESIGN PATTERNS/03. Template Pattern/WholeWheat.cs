using System;
namespace Template_Pattern
{
    public class WholeWheat : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking the Whole Wheat Bread. (15 minutes)");
        }

        public override void MixIngradients()
        {
            Console.WriteLine("Gathering Ingradients for Whole Wheat Bread.");
        }
    }
}
