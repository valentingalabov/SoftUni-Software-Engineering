using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.Cards.Contracts;

namespace PlayersAndMonsters.Models.Cards
{
    public abstract class Card : ICard
    {
        private string name;
        private int damagePoints;
        private int healthPoints;

        protected Card(string name, int damagePoints, int healthPoints)
        {
            this.Name = name;
            this.DamagePoints = damagePoints;
            this.HealthPoints = healthPoints;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ThrowIfStringIsNullOrEmpty(value, "Card's name cannot be null or an empty string.");
                this.name = value;
            }
        }

        public int DamagePoints
        {
            get => this.damagePoints;
            set
            {
                Validator.ThrowIfIntegerIsBelowZero(value, "Card's damage points cannot be less than zero.");
                this.damagePoints = value;
            }
        }

        public int HealthPoints
        {
            get => this.healthPoints;
            private set
            {
                Validator.ThrowIfIntegerIsBelowZero(value, "Card's HP cannot be less than zero.");
                this.healthPoints = value;
            }
        }

        public override string ToString()
        {
            return string.Format(ConstantMessages.CardReportInfo, this.Name, this.DamagePoints);
        }
    }
}
