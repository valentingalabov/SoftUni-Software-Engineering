using System;

namespace Convert.ToDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            try
            {
                double convertToDouble = System.Convert.ToDouble(input);
            }
            catch (FormatException ex)
            {

                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
