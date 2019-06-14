using System;
using System.Collections.Generic;
using System.Text;

namespace Threeuple
{
    public class Threeuple<TItem1,Titem2,Titem3>
    {
        public Threeuple(TItem1 item1, Titem2 item2, Titem3 item3)
        {
            this.Item1 = item1;
            this.Item2 = item2;
            this.Item3 = item3;
        }

        public TItem1 Item1 { get; set; }

        public Titem2 Item2 { get; set; }

        public Titem3 Item3 { get; set; }

        public string GetInfo()
        {
            return $"{Item1} -> {Item2} -> {Item3}";
        }
    }
}
