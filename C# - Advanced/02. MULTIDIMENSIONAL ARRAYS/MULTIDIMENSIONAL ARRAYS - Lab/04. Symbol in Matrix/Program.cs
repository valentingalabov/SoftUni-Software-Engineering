using System;
using System.Linq;

namespace _04._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());
            char[,] matrix = new char[sizeOfMatrix,sizeOfMatrix];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < input.Length; j++)
                {
                    matrix[i, j] = input[j];
                }
            }
            char symbolToFind = char.Parse(Console.ReadLine());
            int rowPosition = 0;
            int colPosition = 0;
            bool foundIt = false;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row,col]==symbolToFind)
                    {
                        rowPosition = row;
                        colPosition = col;
                        foundIt = true;
                        break;
                    }
                    
                }
                if (foundIt)
                {
                    break;
                }
            }
            if (!foundIt)
            {
                Console.WriteLine($"{symbolToFind} does not occur in the matrix");
            }
            else
            {
                Console.WriteLine($"({rowPosition}, {colPosition})");
            }
            
        }
    }
}
