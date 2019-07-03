using System;

namespace CustomStack
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var stack = new StackOfStrings();

            stack.AddRange(new[] { "1", "2", "3", "4" });


        }
    }
}
