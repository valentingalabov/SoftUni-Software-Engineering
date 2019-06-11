using System;

namespace GenericScale
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var scale = new EqualityScale<int>(8, 8);

            Console.WriteLine(scale.AreEqual());

            scale.IsHavier();


        }
    }
}
