using System;
using System.Linq;

namespace _01._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());

            int[,] matrix = new int[sizeOfMatrix, sizeOfMatrix];
            int sumOfPrimaryDiagonal = 0;
            int sumOfSecondaryDiagonal = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] currentLine = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = currentLine[j];
                    if (i == j)
                    {
                        sumOfPrimaryDiagonal += matrix[i, j];
                    }

                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sumOfSecondaryDiagonal += matrix[i,matrix.GetLength(0)-1-i];
            }
            
            Console.WriteLine($"{Math.Abs(sumOfPrimaryDiagonal-sumOfSecondaryDiagonal)}");



        }
    }
}
