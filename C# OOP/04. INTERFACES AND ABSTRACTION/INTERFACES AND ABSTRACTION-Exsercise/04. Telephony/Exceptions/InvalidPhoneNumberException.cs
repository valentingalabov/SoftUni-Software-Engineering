﻿using System;

namespace Telephony.Exceptions
{
    public class InvalidPhoneNumberException : Exception
    {
        private const string EXC_MESSAGE = "Invalid number!";

        public InvalidPhoneNumberException()
            : base(EXC_MESSAGE)
        {
        }

        public InvalidPhoneNumberException(string message) : base(message)
        {
            throw new InvalidPhoneNumberException();
        }
    }
}
