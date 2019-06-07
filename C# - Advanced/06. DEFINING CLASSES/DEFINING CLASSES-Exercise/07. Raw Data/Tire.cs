using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Tire
    {
        private int age;
        private double pressure;

        public Tire(int age, double pressure)
        {
            this.age = age;
            this.pressure = pressure;
        }

        public double Preshure
        {
            get { return this.pressure; }
            
        }

    }
}
