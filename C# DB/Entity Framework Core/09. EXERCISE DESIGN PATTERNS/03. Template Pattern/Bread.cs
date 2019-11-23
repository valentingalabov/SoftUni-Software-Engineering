using System;

namespace Template_Pattern
{
    public abstract class Bread
    {
        public abstract void MixIngradients();

        public abstract void Bake();

        public virtual void Slice()
        {
            Console.WriteLine("Slicing the " + GetType().Name + " bread!");
        
        }

        public void Make()
        {
            MixIngradients();
            Bake();
            Slice();
        
        }


    }
}
