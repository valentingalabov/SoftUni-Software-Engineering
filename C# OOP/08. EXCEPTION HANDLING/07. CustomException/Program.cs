using System;

namespace CustomException
{
    public class Program
    {
        public static void Main(string[] args)
        {
           


            try
            {
                Student student = new Student("Me4o","abv@a.asgf");
            }
            catch (InvalidPersonNameException ex)
            {

                Console.WriteLine(ex.Message);
            }


           
        }
    }
}
