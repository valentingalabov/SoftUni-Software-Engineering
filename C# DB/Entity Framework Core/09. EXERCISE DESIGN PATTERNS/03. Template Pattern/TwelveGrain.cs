using System;

namespace Template_Pattern
{
    public class TwelveGrain : Bread
    {
       

        public override void Bake()
        {
            Console.WriteLine("Gathering Ingradients for 12-Grain Bread.");
        }

        public override void MixIngradients()
        {
            Console.WriteLine("Baking the 12-Grain Bread. (25 minutes)");
        }
    }
}
