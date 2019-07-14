using System;

namespace MilitaryElite.Exceptions
{
    public class InvalidMissionCopletionException : Exception
    {
        private const string EXC_MESSAGE = "You cannot finish already completed mission!";

        public InvalidMissionCopletionException()
            : base(EXC_MESSAGE)
        {

        }

        public InvalidMissionCopletionException(string message) : base(message)
        {

        }
    }
}
