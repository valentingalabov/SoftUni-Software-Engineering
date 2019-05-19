using System;
using System.Linq;

namespace _03._Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());
            int[,] matrix = new int[sizeOfMatrix, sizeOfMatrix];
            int sum = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = tokens[j];
                    if (i == j)
                    {
                        sum += matrix[i, j];
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}
