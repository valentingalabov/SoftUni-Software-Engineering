using System.Linq;
using Telephony.Interfaces;
using Telephony.Exceptions;
namespace Telephony.Models
{
    public class SmartPhone : ICallable, IBrowseble
    {
        public SmartPhone()
        {

        }

        public string Browse(string url)
        {
            if (url.Any(c => char.IsDigit(c)))
            {
                throw new InvalidUrlException();
            }

            return $"Browsing: {url}!";
        }

        public string Call(string phoneNumber)
        {
            if (!phoneNumber.All(c => char.IsDigit(c)))
            {
                throw new InvalidPhoneNumberException();
            }

            return $"Calling... {phoneNumber}";
        }
    }
}
