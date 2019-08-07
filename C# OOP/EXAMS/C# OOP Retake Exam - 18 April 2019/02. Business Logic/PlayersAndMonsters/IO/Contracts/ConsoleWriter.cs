using System;

namespace PlayersAndMonsters.IO.Contracts
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

    }
}