﻿using System;

namespace SimpleSnake.GameObjects
{
    public class Point
    {
        public Point(int leftX, int topY)
        {
            this.LeftX = leftX;
            this.TopY = topY;
        }

        public int LeftX { get; set; }

        public int TopY { get; set; }


        public void Draw(char symnol)
        {
            Console.SetCursorPosition(this.LeftX, this.TopY);
            Console.WriteLine(symnol);
        }

        public void Draw(int leftX, int topY, char symbol)
        {
            Console.SetCursorPosition(leftX, topY);
            Console.WriteLine(symbol);
        }


    }
}
