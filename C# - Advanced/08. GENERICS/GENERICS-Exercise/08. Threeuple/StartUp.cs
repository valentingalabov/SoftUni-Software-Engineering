using System;

namespace Threeuple
{
    public  class StartUp
    {
        public static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine().Split();
            string name = personInfo[0]+" "+personInfo[1];
            string address = personInfo[2];
            string town = string.Empty;
            if (personInfo.Length>4)
            {
                town = personInfo[3] + " " + personInfo[4];
            }
            else
            {
                town = personInfo[3];
            }

            var person = new Threeuple<string, string, string>(name, address, town);

            string[] beerInfo = Console.ReadLine().Split();

            string nameDrinkingBeer = beerInfo[0];
            int litersOfBeer = int.Parse(beerInfo[1]);
            string drunkOrNot = beerInfo[2];
            bool isDrung = false;
            if (drunkOrNot=="drunk")
            {
               isDrung = true;
            }

            var beer = new Threeuple<string, int, bool>(nameDrinkingBeer,litersOfBeer,isDrung);

            string[] bankInfo = Console.ReadLine().Split();
            //{ name}
            //{ account balance}
            //{ bank name}
            string nameForBankInfo = bankInfo[0];
            double accBalance = double.Parse(bankInfo[1]);
            string bankName = bankInfo[2];

            var bank = new Threeuple<string, double, string>(nameForBankInfo,accBalance,bankName);

            Console.WriteLine(person.GetInfo());
            Console.WriteLine(beer.GetInfo());
            Console.WriteLine(bank.GetInfo());
        }
    }
}
