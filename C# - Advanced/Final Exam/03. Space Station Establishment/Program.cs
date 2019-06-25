using System;
using System.Collections.Generic;

namespace _03._Space_Station_Establishment
{
    class Program
    {
        static void Main(string[] args)
        {
            int stephenRow = 0;
            int stephenCol = 0;

            int firstBlackHoleRow = 0;
            int firstBlackHoleCol = 0;

            int secondBlackHoleRow = 0;
            int secondBlackHoleCol = 0;

            int sizeOfGalaxy = int.Parse(Console.ReadLine());

            char[,] galaxy = new char[sizeOfGalaxy, sizeOfGalaxy];
            int countOfHole = 0;
            for (int i = 0; i < sizeOfGalaxy; i++)
            {
                string currenLine = Console.ReadLine();

                for (int j = 0; j < currenLine.Length; j++)
                {
                    galaxy[i, j] = currenLine[j];

                    if (galaxy[i, j] == 'S')
                    {
                        stephenRow = i;
                        stephenCol = j;
                    }
                    else if (galaxy[i, j] == 'O')
                    {
                        countOfHole++;
                        if (countOfHole < 2)
                        {
                            firstBlackHoleRow = i;
                            firstBlackHoleCol = j;
                        }
                        else
                        {
                            secondBlackHoleRow = i;
                            secondBlackHoleCol = j;
                        }


                    }
                }
            }

            int sumOfStarPower = 0;

            while (sumOfStarPower < 50)
            {
                string command = Console.ReadLine();
                if (command == "up")
                {
                    galaxy[stephenRow, stephenCol] = '-';
                    stephenRow--;
                    if (stephenRow < 0)
                    {
                        Console.WriteLine("Bad news, the spaceship went to the void.");
                        Console.WriteLine($"Star power collected: {sumOfStarPower}");
                        PrintTheMatrix(galaxy);
                        return;
                    }

                    else if (galaxy[stephenRow, stephenCol] == 'O')
                    {
                        if (stephenRow == firstBlackHoleRow && stephenCol == firstBlackHoleCol)
                        {
                            galaxy[stephenRow, stephenCol] = '-';

                            galaxy[secondBlackHoleRow, secondBlackHoleCol] = 'S';
                            stephenRow = secondBlackHoleRow;
                            stephenCol = secondBlackHoleCol;
                            
                        }
                        else if (stephenRow == secondBlackHoleRow && stephenCol == secondBlackHoleCol)
                        {
                            galaxy[stephenRow, stephenCol] = '-';

                            galaxy[firstBlackHoleRow, firstBlackHoleCol] = 'S';
                            stephenRow = firstBlackHoleRow;
                            stephenCol = firstBlackHoleCol;
                        }
                    }
                    else if (char.IsDigit(galaxy[stephenRow, stephenCol]))
                    {
                        string numberToAdd = galaxy[stephenRow, stephenCol].ToString();
                        sumOfStarPower += int.Parse(numberToAdd);

                        galaxy[stephenRow, stephenCol] = 'S';
                        
                    }
                    else
                    {
                        
                        galaxy[stephenRow, stephenCol] = 'S';
                    }

                }


                if (command == "down")
                {
                    galaxy[stephenRow, stephenCol] = '-';
                    stephenRow++;
                    if (stephenRow > sizeOfGalaxy-1)
                    {
                        Console.WriteLine("Bad news, the spaceship went to the void.");
                        Console.WriteLine($"Star power collected: {sumOfStarPower}");
                        PrintTheMatrix(galaxy);
                        return;
                    }

                    else if (galaxy[stephenRow, stephenCol] == 'O')
                    {
                        if (stephenRow == firstBlackHoleRow && stephenCol == firstBlackHoleCol)
                        {
                            galaxy[stephenRow, stephenCol] = '-';

                            galaxy[secondBlackHoleRow, secondBlackHoleCol] = 'S';
                            stephenRow = secondBlackHoleRow;
                            stephenCol = secondBlackHoleCol;

                        }
                        else if (stephenRow == secondBlackHoleRow && stephenCol == secondBlackHoleCol)
                        {
                            galaxy[stephenRow, stephenCol] = '-';

                            galaxy[firstBlackHoleRow, firstBlackHoleCol] = 'S';
                            stephenRow = firstBlackHoleRow;
                            stephenCol = firstBlackHoleCol;
                        }
                    }
                    else if (char.IsDigit(galaxy[stephenRow, stephenCol]))
                    {
                        string numberToAdd = galaxy[stephenRow, stephenCol].ToString();
                        sumOfStarPower += int.Parse(numberToAdd);

                        galaxy[stephenRow, stephenCol] = 'S';

                    }
                    else
                    {

                        galaxy[stephenRow, stephenCol] = 'S';
                    }

                }


                if (command == "left")
                {
                    galaxy[stephenRow, stephenCol] = '-';
                    stephenCol--;
                    if (stephenCol < 0)
                    {
                        Console.WriteLine("Bad news, the spaceship went to the void.");
                        Console.WriteLine($"Star power collected: {sumOfStarPower}");
                        PrintTheMatrix(galaxy);
                        return;
                    }

                    else if (galaxy[stephenRow, stephenCol] == 'O')
                    {
                        if (stephenRow == firstBlackHoleRow && stephenCol == firstBlackHoleCol)
                        {
                            galaxy[stephenRow, stephenCol] = '-';

                            galaxy[secondBlackHoleRow, secondBlackHoleCol] = 'S';
                            stephenRow = secondBlackHoleRow;
                            stephenCol = secondBlackHoleCol;

                        }
                        else if (stephenRow == secondBlackHoleRow && stephenCol == secondBlackHoleCol)
                        {
                            galaxy[stephenRow, stephenCol] = '-';

                            galaxy[firstBlackHoleRow, firstBlackHoleCol] = 'S';
                            stephenRow = firstBlackHoleRow;
                            stephenCol = firstBlackHoleCol;
                        }
                    }
                    else if (char.IsDigit(galaxy[stephenRow, stephenCol]))
                    {
                        string numberToAdd = galaxy[stephenRow, stephenCol].ToString();
                        sumOfStarPower += int.Parse(numberToAdd);

                        galaxy[stephenRow, stephenCol] = 'S';

                    }
                    else
                    {

                        galaxy[stephenRow, stephenCol] = 'S';
                    }

                }


                if (command == "right")
                {
                    galaxy[stephenRow, stephenCol] = '-';
                    stephenCol++;
                    if (stephenCol > sizeOfGalaxy-1)
                    {
                        Console.WriteLine("Bad news, the spaceship went to the void.");
                        Console.WriteLine($"Star power collected: {sumOfStarPower}");
                        PrintTheMatrix(galaxy);
                        return;
                    }

                    else if (galaxy[stephenRow, stephenCol] == 'O')
                    {
                        if (stephenRow == firstBlackHoleRow && stephenCol == firstBlackHoleCol)
                        {
                            galaxy[stephenRow, stephenCol] = '-';

                            galaxy[secondBlackHoleRow, secondBlackHoleCol] = 'S';
                            stephenRow = secondBlackHoleRow;
                            stephenCol = secondBlackHoleCol;

                        }
                        else if (stephenRow == secondBlackHoleRow && stephenCol == secondBlackHoleCol)
                        {
                            galaxy[stephenRow, stephenCol] = '-';

                            galaxy[firstBlackHoleRow, firstBlackHoleCol] = 'S';
                            stephenRow = firstBlackHoleRow;
                            stephenCol = firstBlackHoleCol;
                        }
                    }
                    else if (char.IsDigit(galaxy[stephenRow, stephenCol]))
                    {
                        string numberToAdd = galaxy[stephenRow, stephenCol].ToString();
                        sumOfStarPower += int.Parse(numberToAdd);

                        galaxy[stephenRow, stephenCol] = 'S';

                    }
                    else
                    {

                        galaxy[stephenRow, stephenCol] = 'S';
                    }

                }





            }

            Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
            Console.WriteLine($"Star power collected: {sumOfStarPower}");
            PrintTheMatrix(galaxy);


        }

        private static void PrintTheMatrix(char[,] galaxy)
        {
            for (int row = 0; row < galaxy.GetLength(0); row++)
            {
                for (int col = 0; col < galaxy.GetLength(1); col++)
                {
                    Console.Write(galaxy[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
