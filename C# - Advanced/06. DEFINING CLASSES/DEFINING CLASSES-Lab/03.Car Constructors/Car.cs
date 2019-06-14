﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Car_Constructors
{
    public class Car
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public void Drive(double distance)
        {
            bool canContinue =
                this.FuelQuantity - (distance * this.FuelConsumption) / 100 >= 0;

            if (canContinue)

            {
                this.FuelQuantity -= (distance * this.FuelConsumption) / 100;
            }
            else
            {
                Console.WriteLine($"Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Make: {this.Make}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"Year: {this.Year}");
            sb.AppendLine($"FuelQuantity: {this.FuelQuantity:F2}L");
            sb.AppendLine($"FuelConsumption: {this.FuelConsumption:F2}L");
            return sb.ToString();
        }

        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.FuelConsumption = 10;
        }


        public Car(string make, string model, int year) : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;

        }

        public Car(string make,string model,int year,double fuelQuantity,double fuelConsumption) : this(make,model,year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }



    }
}