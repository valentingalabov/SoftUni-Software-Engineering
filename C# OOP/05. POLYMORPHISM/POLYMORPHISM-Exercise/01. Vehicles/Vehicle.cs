﻿namespace Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        private double FuelQuantity { get; set; }

        private double FuelConsumption { get; set; }

        protected abstract double AdditionalConsumption { get; }

        public string Drive(double distance)
        {
            double requiredFuel = (FuelConsumption + AdditionalConsumption) * distance;

            if (requiredFuel <= FuelQuantity)
            {
                FuelQuantity -= requiredFuel;
                return $"{this.GetType().Name} travelled {distance} km";
            }

            return $"{this.GetType().Name} needs refueling";

        }

        public virtual void Refuel(double fuel)
        {
            FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:F2} ";
        }

    }
}
