using System;

namespace _05._Date_Modifier
{
   public class StartUp
    {
        public static void Main(string[] args)
        {
            string date1 = Console.ReadLine();
            string date2 = Console.ReadLine();

            DateModifier date = new DateModifier(date1, date2);

            int result = Math.Abs(date.DateDifference(date1,date2));

            Console.WriteLine(result);
        }
    }
}
