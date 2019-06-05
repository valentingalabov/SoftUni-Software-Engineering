using System;
using System.Collections.Generic;
using System.Text;

namespace _05.Special_Cars
{
    public class Engine
    {
   
        public int HorsePower { get; set; }
        public double CubicCapacity { get; set; }

        public Engine(int horsePower,double cubicCapacity)
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }

    }
}
