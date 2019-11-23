using System;

namespace _02._Composite
{
    public class SingleGift : GiftBase
    {
        public SingleGift(string name, int price)
            : base(name, price)
        {

        }

        public override int CaucateTotalPrice()
        {
            Console.WriteLine($"{name} with the price {price}");

            return price;
        }
    }
}
