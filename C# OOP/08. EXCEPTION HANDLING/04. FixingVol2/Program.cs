using System;

namespace FixingVol2
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1, num2;

            byte result;

            num1 = 30;
            num2 = 60;
            result = 0;
            try
            {
                result = Convert.ToByte(num1 * num2);
                Console.WriteLine($"{num1} x {num2} = {result}");
                Console.ReadLine();
            }
            catch (OverflowException)
            {

                Console.WriteLine("Byte must be between [0..255]");
            }
           

           
        }
    }
}
