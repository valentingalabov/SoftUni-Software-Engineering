using System;
using System.Collections.Generic;
using System.Linq;
namespace _02._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(input);
            var commandInfo = Console.ReadLine().ToLower();
            while (commandInfo != "end")
            {
                var tokens = commandInfo.Split();
                var command = tokens[0].ToLower();

                if (command == "add")
                {
                    int firstNumberToAdd = int.Parse(tokens[1]);
                    int secondNumberToAdd = int.Parse(tokens[2]);
                    stack.Push(firstNumberToAdd);
                    stack.Push(secondNumberToAdd);
                }
                else if (command == "remove")
                {
                    var countOfRemovedNums = int.Parse(tokens[1]);
                    if (stack.Count >= countOfRemovedNums)
                    {
                        for (int i = 0; i < countOfRemovedNums; i++)
                        {
                            stack.Pop();
                        }
                    }
                    
                    
                }
                commandInfo = Console.ReadLine().ToLower();
            }
            var sum = stack.Sum();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
