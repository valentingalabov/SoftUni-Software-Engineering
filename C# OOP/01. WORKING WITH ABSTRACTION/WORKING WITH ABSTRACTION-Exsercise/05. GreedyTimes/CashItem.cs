using System;
using System.Collections.Generic;
using System.Text;

namespace P05_GreedyTimes
{
    public class CashItem : Item
    {
        public CashItem(string key, long value)
        {
            Key = key;
            Value = value;
        }
    }
}