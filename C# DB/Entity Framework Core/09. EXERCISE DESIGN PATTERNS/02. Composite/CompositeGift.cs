using System;
using System.Collections.Generic;

namespace _02._Composite
{
    public class CompositeGift : GiftBase, IGiftOperations
    {

        private List<GiftBase> _gifts;

        public CompositeGift(string name, int price)
            : base(name, price)
        {
            this._gifts = new List<GiftBase>();
        }

        public void Add(GiftBase gift)
        {
            this._gifts.Add(gift);
        }

        public void Remove(GiftBase gift)
        {
            this._gifts.Remove(gift);
        }

        public override int CaucateTotalPrice()
        {
            int total = 0;

            Console.WriteLine($"{name} contains the following products with prices:");

            foreach (var gift in _gifts)
            {
                total += gift.CaucateTotalPrice();
            }

            return total;
        }


    }
}
