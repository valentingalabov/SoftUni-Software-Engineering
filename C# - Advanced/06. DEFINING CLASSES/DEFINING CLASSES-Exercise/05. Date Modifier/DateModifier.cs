using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05._Date_Modifier
{
    public class DateModifier
    {
        public string Date1 { get; set; }
        public string Date2 { get; set; }

        public DateModifier(string date1,string date2)
        {
            Date1 = date1;
            Date2 = date2;
        }

        public int DateDifference(string date1, string date2)
        {
            int[] d1 = date1.Split().Select(int.Parse).ToArray();
            int[] d2 = date2.Split().Select(int.Parse).ToArray();

            DateTime dateOne = new DateTime(d1[0], d1[1], d1[2]);
            DateTime dateTwo = new DateTime(d2[0], d2[1], d2[2]);

            TimeSpan difference = dateOne.Subtract(dateTwo);
            return (int)(difference.TotalDays);
        }
    }
}
