using MortalEngines.Entities.Contracts;
using System;

namespace MortalEngines.Entities
{
    public class Fighter : BaseMachine, IFighter
    {
        



        public Fighter(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints += 50, defensePoints -= 25, 200)
        {

        }

        public bool AggressiveMode
        {
            get
            {
                return this.AggressiveMode;
            }
            private set
            {
                this.AggressiveMode = true;
            }
        }

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode)
            {
                this.AggressiveMode = false;
                AttackPoints -= 50;
                DefensePoints += 25;
            }
            else
            {
                this.AggressiveMode = true;
                AttackPoints += 50;
                DefensePoints -= 25;
            }

        }

        public override string ToString()
        {
            if (AggressiveMode)
            {
                return base.ToString() + Environment.NewLine +
                $" *Aggressive: ON";
            }
            else
            {
                return base.ToString() + Environment.NewLine +
                $" *Aggressive: OFF";
            }

        }
    }
}
