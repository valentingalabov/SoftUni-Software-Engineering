using System;
using System.Collections.Generic;
using System.Text;

namespace _01._Car
{
    public class Car
    {
        private int year;
        private string make;

        public string Make
        {
            get
            {
                return make;
            }
            set
            {
                this.make = value;
            }
        }

        public string Model { get; set; }

        public int Year { get; set; }




    }
}
