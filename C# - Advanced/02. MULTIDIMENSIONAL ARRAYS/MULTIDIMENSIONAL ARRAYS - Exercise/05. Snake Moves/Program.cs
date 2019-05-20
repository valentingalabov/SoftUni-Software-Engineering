using System;
using System.Linq;

namespace _05._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];

            char[] snake = Console.ReadLine().ToCharArray();

            char[][] snakePath = new char[rows][];

            for (int i = 0; i < rows; i++)
            {
                if (snake.Length==cols)
                {
                    snakePath[i]=snake;
                }
                else if (snake.Length<cols)
                {
                   int toAdd= snake.Length - cols;
                    for (int j = 0; j < toAdd; j++)
                    {
                        snake[i] = snake[j];
                    }
                }
                
            }



        }
    }
}
