using System;
using System.Linq;

namespace _03._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = size[0];
            int cols = size[1];
            int maxSum = int.MinValue;
            int[][] matrix = new int[rows][];
            
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }
            int startRowIndex = 0;
            int startColIndex = 0;
            for (int i = 0; i < rows - 2; i++)
            {
                for (int j = 0; j < cols - 2; j++)
                {
                    int currSum = matrix[i][j] + matrix[i][j + 1] + matrix[i][j + 2]
                        + matrix[i + 1][j] + matrix[i + 1][j + 1] + matrix[i + 1][j + 2]
                        + matrix[i + 2][j] + matrix[i + 2][j + 1] + matrix[i + 2][j + 2];
                    if (currSum > maxSum)
                    {
                        maxSum = currSum;
                        startRowIndex = i;
                        startColIndex = j;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine($"{matrix[startRowIndex][startColIndex]} {matrix[startRowIndex][startColIndex+1]} {matrix[startRowIndex][startColIndex+2]}\n" +
                $"{matrix[startRowIndex+1][startColIndex]} {matrix[startRowIndex+1][startColIndex+1]} {matrix[startRowIndex+1][startColIndex+2]}\n" +
                $"{matrix[startRowIndex+2][startColIndex]} {matrix[startRowIndex+2][startColIndex+1]} {matrix[startRowIndex+2][startColIndex+2]}");
        }
    }
}
