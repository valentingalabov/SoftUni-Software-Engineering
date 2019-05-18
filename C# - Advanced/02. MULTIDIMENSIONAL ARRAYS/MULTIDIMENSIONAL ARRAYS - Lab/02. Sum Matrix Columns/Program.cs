using System;
using System.Linq;

namespace _02._Sum_Matrix_Columns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dim = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[,] arr = new int[dim[0], dim[1]];
            

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                int[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = tokens[j];
                }
            }

            for (int col = 0; col < arr.GetLength(1); col++)
            {
                int sum = 0;

                for (int row = 0; row < arr.GetLength(0); row++)
                {
                    sum += arr[row, col];
                }
                Console.WriteLine(sum);
                sum = 0;
            }

        }
    }
}
