﻿namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double additionConsumptionPerKm = 0.9;

        public Car(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {

        }

        protected override double AdditionalConsumption => additionConsumptionPerKm;
    }
}
