using System;

namespace LaptopShop
{
   public class StartUp
    {
        public static void Main(string[] args)
        {
            string laptopName = "ASUS";
            string laptopModel = "Rog HV34123";
            double laptopDisplaySize = 15.3;
            decimal laptopPrice = 333;
            int laptopRam = 32;
            int laptopSsd = 256;

            Laptop laptop =
                new Laptop(laptopName,laptopModel,laptopDisplaySize,laptopPrice, laptopRam, laptopSsd);

            var laptopInfo = laptop.FullInfo();

            

            var shop = new Shop();
            shop.AddLaptop(laptop);
            shop.AddLaptop(laptop);
            
            Console.WriteLine(shop.Count);
            


        }
    }
}
 