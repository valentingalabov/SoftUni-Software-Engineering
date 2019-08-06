using System;

namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle
    {

        private const double PowerMotorcycleCubicCentimeters = 450;
        private const double PowerMotorcycleMinHp= 70;
        private const double PowerMotorcycleMaxHp= 100;
        private int horsePower;

        public PowerMotorcycle(string model, int horsePower)
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

                if (value<PowerMotorcycleMinHp || value>PowerMotorcycleMaxHp)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }
                horsePower = value;
            }
        }
    }
}
