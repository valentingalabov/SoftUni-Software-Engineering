using System;
using System.Linq;
using System.Text;

namespace Stack
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            var stack = new Stack<int>();

            var comand = Console.ReadLine();
            while (!comand.Equals("END"))
            {
                var comandArgs = comand.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (comandArgs[0].Equals("Push"))
                {
                    var numbers = comandArgs.Skip(1).ToList().Select(int.Parse).ToList();
                    foreach (var number in numbers)
                    {
                        stack.Push(number);
                    }
                }
                else
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                comand = Console.ReadLine();
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
        

    }


}


