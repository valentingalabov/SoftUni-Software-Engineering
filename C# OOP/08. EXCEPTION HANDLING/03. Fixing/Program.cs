using System;

namespace Fixing
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] weekDays = new string[5];

            weekDays[0] = "Sunday";
            weekDays[1] = "Monday";
            weekDays[2] = "Tuesday";
            weekDays[3] = "Wednesday";
            weekDays[4] = "Thursday";

            try
            {
                // [i]must be only < 5 not <=5
                for (int i = 0; i <= 5; i++)
                {
                    Console.WriteLine(weekDays[i].ToString());
                }
            }
            catch (IndexOutOfRangeException ex)
            {

                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();

        }
    }
}
