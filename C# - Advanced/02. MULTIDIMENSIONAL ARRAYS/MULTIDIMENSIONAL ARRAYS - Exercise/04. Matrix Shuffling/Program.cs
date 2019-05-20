using System;
using System.Linq;

namespace _04._Matrix_Shuffling
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
            string[][] matrix = new string[rows][];

            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (tokens.Length!=5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                string currCommand = tokens[0];
                int firstRow = int.Parse(tokens[1]);
                int firstCol = int.Parse(tokens[2]);
                int secondRow = int.Parse(tokens[3]);
                int secondCol = int.Parse(tokens[4]);

                if (currCommand != "swap" || firstRow > rows - 1 || firstCol > cols - 1 || secondRow > rows - 1 || secondCol > cols - 1)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                
                        string temp = matrix[firstRow][firstCol];
                        matrix[firstRow][firstCol] = matrix[secondRow][secondCol];
                        matrix[secondRow][secondCol] = temp;
                 
                foreach (var item in matrix)
                {
                    Console.WriteLine(string.Join(" ", item));
                }

            }

        }
    }
}
