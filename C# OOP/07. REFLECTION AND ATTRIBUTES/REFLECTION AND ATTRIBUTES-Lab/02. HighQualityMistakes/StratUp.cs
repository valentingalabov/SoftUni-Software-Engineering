using System;

namespace HighQualityMistakes
{
    public class StratUp
    {
        public static void Main(string[] args)
        {
            Spy spy = new Spy();

            string result = spy.AnalyzeAcessModifiers("Hacker");

            Console.WriteLine(result);
        }
    }
}
