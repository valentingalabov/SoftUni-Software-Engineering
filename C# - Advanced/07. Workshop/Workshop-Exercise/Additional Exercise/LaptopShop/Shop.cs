using System;
using System.Collections.Generic;
using System.Text;

namespace LaptopShop
{
    public class Shop
    {
        private Dictionary<string, List<Laptop>> laptops;

        public Shop()
        {
            this.laptops = new Dictionary<string, List<Laptop>>();
        }

        public int Count => this.laptops.Count;

        public void AddLaptop(Laptop laptop)
        {
            IfNullThrowException(laptop);

            if (!this.laptops.ContainsKey(laptop.Make))
            {
                laptops.Add(laptop.Make, new List<Laptop>());
            }

            this.laptops[laptop.Make].Add(laptop);
        }

        public bool RemoveLaptop(Laptop laptop)
        {
            IfNullThrowException(laptop);

            if (!this.laptops.ContainsKey(laptop.Make))
            {
                return false;
            }
            if (!this.laptops[laptop.Make].Contains(laptop))
            {
                return false;
            }

            bool isRemove = this.laptops[laptop.Make].Remove(laptop);

            if (this.laptops[laptop.Make].Count == 0)
            {
                isRemove = this.laptops.Remove(laptop.Make);
            }

            return isRemove;
        }

        public void PrintAllLaptops(Action<Laptop> action)
        {
            foreach (var (make,dictLaptops) in this.laptops)
            {
                foreach (var laptop in dictLaptops)
                {
                    action(laptop);
                }
            }

        }

        public bool ContainsLaptop(Laptop laptop)
        {
            IfNullThrowException(laptop);

            if (!this.laptops.ContainsKey(laptop.Make))
            {
                return false;
            }
            if (this.laptops[laptop.Make].Contains(laptop))
            {
                return false; 
            }

            return true;

        }



        private void IfNullThrowException(Laptop laptop)
        {
            if (laptop == null)
            {
                throw new ArgumentNullException(nameof(laptop), "Object cannot be null");
            }
        }
    }
}
