using System;
using System.Linq;
using Telephony.Exceptions;
using Telephony.Models;

namespace Telephony.Core
{
    public class Engine
    {
        private SmartPhone smartphone;

        public Engine()
        {
            this.smartphone = new SmartPhone();
        }

        public Engine(SmartPhone smartphone)
        {
            this.smartphone = smartphone;
        }
        public void Run()
        {
            string[] numbers = Console.ReadLine()
                .Split(" ")
                .ToArray();
            string[] urls = Console.ReadLine()
                .Split(" ")
                .ToArray();

            CallNumbers(numbers);
            BrowseInternet(urls);


        }

        private void BrowseInternet(string[] urls)
        {


            foreach (var url in urls)
            {
                try
                {
                    Console.WriteLine(this.smartphone.Browse(url));
                }
                catch (InvalidUrlException iue)
                {

                    Console.WriteLine(iue.Message);
                }


            }
        }

        private void CallNumbers(string[] numbers)
        {
            foreach (var number in numbers)
            {
                try
                {
                    Console.WriteLine(this.smartphone.Call(number));
                }
                catch (InvalidPhoneNumberException ipne)
                {

                    Console.WriteLine(ipne.Message);
                }
                
            }
        }
    }
}
