﻿namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
            DefaultFuelConsumption = 1.25;
        }

        public int HorsePower { get; set; }

        public double Fuel { get; set; }

        public double DefaultFuelConsumption { get; set; }

        public virtual double FuelConsumption { get; set; }

        public virtual void Drive(double kilometers)
        {
            FuelConsumption = DefaultFuelConsumption * kilometers;
            Fuel -= FuelConsumption;
        }
    }
}