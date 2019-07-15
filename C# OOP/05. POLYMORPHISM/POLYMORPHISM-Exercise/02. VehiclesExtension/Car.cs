namespace VehiclesExtension
{
    public class Car : Vehicle
    {
        private const double additionConsumptionPerKm = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapaciti) 
            : base(fuelQuantity, fuelConsumption, tankCapaciti)
        {
        }

        protected override double AdditionalConsumption => additionConsumptionPerKm;
    }
}
