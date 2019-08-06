using System;

namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        private const double PowerMotorcycleCubicCentimeters = 125;
        private const double PowerMotorcycleMinHp = 50;
        private const double PowerMotorcycleMaxHp = 69;
        private int horsePower;

        public SpeedMotorcycle(string model, int horsePower)
            : base(model, horsePower, PowerMotorcycleCubicCentimeters)
        {

        }

        public override int HorsePower
        {
            get
            {
                return horsePower;
            }
            protected set
            {

                if (value < PowerMotorcycleMinHp || value > PowerMotorcycleMaxHp)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }
                horsePower = value;
            }
        }
    }
}
