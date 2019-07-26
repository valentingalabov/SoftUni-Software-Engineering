using System;

namespace EnterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                for (int i = 1; i <= 10; i++)
                {
                    Console.Write("Enter number in range [1...100] : ");
                    int number = ReadNumber(1, 100, i);
                }
            }
            catch (FormatException)
            {

                Console.WriteLine("The number is NOT integer!");
            }
            catch (ArgumentNullException)
            {

                Console.WriteLine("The number is NOT integer!");
            }
            catch (OverflowException)
            {

                Console.WriteLine("The number is NOT in the range of integer.");
            }
            catch (ArgumentOutOfRangeException)
            {

                Console.WriteLine("The number is NOT in the range.");
            }

        }

        static int ReadNumber(int start, int end, int i)
        {
            int number = int.Parse(Console.ReadLine());
            if (number < start || number > end || number < i)
            {
                throw new ArgumentOutOfRangeException();
            }

            return number;
        }
    }
}
