using System;
using System.Linq;

namespace _02._Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = input[0];
            int cols = input[1];
            char[][] matrix = new char[rows][];
            int counter = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                
            }

            for (int i = 0; i < rows-1; i++)
            {
                for (int j = 0; j < cols-1; j++)
                {

                    if (matrix[i][j] == matrix[i][j + 1]
                        && matrix[i][j] == matrix[i + 1][j]
                        && matrix[i][j] == matrix[i + 1][j + 1])
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
