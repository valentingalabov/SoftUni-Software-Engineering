using System;

namespace SquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                uint i = uint.Parse(Console.ReadLine());
                var result = Math.Sqrt(i);
            }
            catch (Exception)
            {

                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
