using System;

namespace MissionPrivateImpossible
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Spy spy = new Spy();

            string resut = spy.RevealPrivateMethods("Hacker");
            Console.WriteLine(resut);
        }
    }
}
