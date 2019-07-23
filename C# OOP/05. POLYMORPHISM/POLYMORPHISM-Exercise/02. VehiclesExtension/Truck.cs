﻿namespace VehiclesExtension
{
    public class Truck : Vehicle
    {

        private const double additionConsumptionPerKm = 1.6;

        private const double refuelingCoefficient = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapaciti) 
            : base(fuelQuantity, fuelConsumption, tankCapaciti)
        {
        }

        protected override double AdditionalConsumption => additionConsumptionPerKm;

        public override void Refuel(double fuel)
        {
            base.Refuel(fuel);
            this.FuelQuantity -= (1 - refuelingCoefficient) * fuel;
        }

    }
}