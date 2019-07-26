using System;

namespace ValidPerson
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Person pesho = new Person("Pesho", "Peshev", 24);

            try
            {
                Person noName = new Person(string.Empty, "Peshev", 24);
            }
            catch (ArgumentNullException ex)
            {

                Console.WriteLine($"Exception throw: {ex.Message}");
            }
            catch (ArgumentOutOfRangeException ex)
            {

                Console.WriteLine($"Exception throw: {ex.Message}");
            }

            try
            {
                Person noLastName = new Person("Ivan", null, 24);
            }
            catch (ArgumentNullException ane)
            {

                Console.WriteLine($"Exception throw: {ane.Message}");
            }
            catch (ArgumentOutOfRangeException ex)
            {

                Console.WriteLine($"Exception throw: {ex.Message}");
            }


            try
            {
                Person penegativeAge = new Person("Stoyan", "Kolev", -1);
            } 
            
            catch (ArgumentOutOfRangeException ex)
            {

                Console.WriteLine($"Exception throw: {ex.Message}");
            }

            try
            {
                Person tooOldForThisProgram = new Person("Iskren", "Pecov", 121);
            }

            catch (ArgumentOutOfRangeException ex)
            {

                Console.WriteLine($"Exception throw: {ex.Message}");
            }




           
        }
    }
}
