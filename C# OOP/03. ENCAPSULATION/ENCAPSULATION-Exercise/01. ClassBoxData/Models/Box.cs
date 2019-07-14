using System;
using System.Collections.Generic;
using System.Text;
using ClassBoxData.Exceptions;
namespace ClassBoxData.Models
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Lenght = length;
            this.Width = width;
            this.Height = height;
        }

        public double Lenght
        {
            get
            {
                return this.length;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.LenghtZeroOrNegativeException);
                }
                this.length = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.WidthZeroOrNegativeException);
                }
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.HeightZeroOrNegativeException);
                }
                this.height = value;
            }
        }



        public double SurfaceArea()
        {
            double surfaceArea = 2 * this.Lenght * this.Width + 2 * this.Lenght * this.Height + 2 * this.Width * this.Height;
            return surfaceArea;
        }

        public double LateralSurfaceArea()
        {
            double leteralSurfaceArea = 2 * this.Lenght * this.Height + 2 * this.Width * this.Height;
            return leteralSurfaceArea;
        }
        public double Volume()
        {
            double volume = this.Lenght * this.Height * this.Width;

            return volume;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Surface Area - {SurfaceArea():F2}");
            result.AppendLine($"Lateral Surface Area - {LateralSurfaceArea():F2}");
            result.AppendLine($"Volume - {Volume():F2}");

            return result.ToString().TrimEnd();



        }

    }
}
