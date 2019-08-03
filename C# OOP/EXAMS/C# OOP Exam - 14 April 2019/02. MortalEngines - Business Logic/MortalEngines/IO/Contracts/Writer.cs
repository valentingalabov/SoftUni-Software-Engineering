using System;

namespace MortalEngines.IO.Contracts
{
    public class Writer : IWriter
    {
        public void Write(string content)
        {
            Console.WriteLine(content);
        }
    }
}
