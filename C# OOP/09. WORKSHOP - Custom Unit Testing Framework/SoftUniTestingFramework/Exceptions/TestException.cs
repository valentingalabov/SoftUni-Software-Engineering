using System;

namespace SoftUniTestingFramework.Exceptions
{
    public class TestException : Exception
    {
        public TestException(string message)
            : base(message)
        {
        }
    }
}
