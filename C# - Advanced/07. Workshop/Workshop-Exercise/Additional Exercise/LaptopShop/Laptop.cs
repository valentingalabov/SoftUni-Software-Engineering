using System;
using System.Collections.Generic;
using System.Text;

namespace LaptopShop
{
    public class Laptop
    {
        public Laptop(string make,
            string model,
            double displaySize,
            decimal price,
            int ram,
            int? ssd = null)
        {
            this.Make = make;
            this.Model = model;
            this.DisplaySize = displaySize;
            this.Price = price;
            this.Ram = ram;
            this.Ssd = ssd;
        }

        public string Make { get; private set; }

        public string Model { get; private set; }

        public double DisplaySize { get; private set; }

        public decimal Price { get; private set; }

        public int Ram { get; private set; }

        public int? Ssd { get; private set; }

        public string FullInfo()
        {
            return $@"Make: {this.Make}
Model: {this.Model}
Price: {this.Price:F2}";
        }

    }
}
