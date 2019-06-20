using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Socks
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sequenceOfLeftSocks = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] sequenceOfRightSocks = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> leftSocks = new Stack<int>(sequenceOfLeftSocks);
            Queue<int> rightSocks = new Queue<int>(sequenceOfRightSocks);
            List<int> pairs = new List<int>();

            while (leftSocks.Count > 0 && rightSocks.Count > 0)
            {

                if (leftSocks.Peek() > rightSocks.Peek())
                {
                    pairs.Add(leftSocks.Peek() + rightSocks.Peek());
                    leftSocks.Pop();
                    rightSocks.Dequeue();
                }
                else if (leftSocks.Peek() < rightSocks.Peek())
                {
                    leftSocks.Pop();
                    continue;
                }
                else if (leftSocks.Peek() == rightSocks.Peek())
                {
                    rightSocks.Dequeue();
                    int currLeftSock = leftSocks.Pop();
                    leftSocks.Push(currLeftSock + 1);
                }
            }

            var biggestPair = pairs.OrderByDescending(x=>x).FirstOrDefault();
            Console.WriteLine(biggestPair);
            Console.WriteLine(string.Join(" ",pairs));


        }
    }
}
