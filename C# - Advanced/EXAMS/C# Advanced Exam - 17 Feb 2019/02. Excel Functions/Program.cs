using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Excel_Functions
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            string[][] matrix = new string[rows][];

            for (int i = 0; i < matrix.Length; i++)
            {
                string[] input = Console.ReadLine().Split(", ").ToArray();
                matrix[i] = input;
            }

            string[] command = Console.ReadLine().Split();
            string header = command[1];
            int headerIndex = Array.IndexOf(matrix[0], header);

            if (command[0] == "hide")
            {


                for (int row = 0; row < matrix.Length; row++)
                {
                    List<string> lineToPrint = new List<string>(matrix[row]);
                    lineToPrint.RemoveAt(headerIndex);

                    //lineToPrint.AddRange(matrix[row].Take(headerIndex));
                    //lineToPrint.AddRange(matrix[row].Skip(headerIndex + 1));

                    Console.WriteLine(string.Join(" | ", lineToPrint));

                    //Console.WriteLine(string.Join(" | ",matrix[row]
                    //    .Where((x,i)=>i !=headerIndex)
                    //    .ToArray()));

                    matrix[row] = lineToPrint.ToArray();
                }

            }
            else if (command[0] == "sort")
            {
                string[] headerRow = matrix[0];

                Console.WriteLine(string.Join(" | ", headerRow));

                matrix = matrix.OrderBy(x => x[headerIndex]).ToArray();


                foreach (var row in matrix)
                {
                    if (row != headerRow)
                    {
                        Console.WriteLine(string.Join(" | ", row));
                    }
                }
            }

            else if (command[0] == "filter")
            {
                string parameter = command[2];
                string[] headerRow = matrix[0];

                Console.WriteLine(string.Join(" | ", headerRow));

                for (int i = 1; i < matrix.Length; i++)
                {
                    if (matrix[i][headerIndex] == parameter)
                    {
                        Console.WriteLine(string.Join(" | ", matrix[i]));
                    }
                }
            }



        }
    }
}
