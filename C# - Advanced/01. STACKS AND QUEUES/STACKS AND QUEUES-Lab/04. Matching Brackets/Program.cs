using System;
using System.Collections.Generic;

namespace Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string expr = Console.ReadLine();
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < expr.Length; i++)
            {
                if (expr[i] == '(')
                {
                    stack.Push(i);
                }
                else if (expr[i] == ')')
                {
                    int index = stack.Pop();
                    Console.WriteLine(expr.Substring(index, i - index + 1));
                }
            }

        }
    }
}
