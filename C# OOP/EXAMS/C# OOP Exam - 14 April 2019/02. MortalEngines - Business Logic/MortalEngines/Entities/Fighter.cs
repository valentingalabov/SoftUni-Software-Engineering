using MortalEngines.Entities.Contracts;
using System;

namespace MortalEngines.Entities
{
    public class Fighter : BaseMachine, IFighter
    {
        private bool aggressiveMode;
        



        public Fighter(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints += 50, defensePoints -= 25, 200)
        {

        }

        public bool AggressiveMode
        {
            get
            {
                return this.aggressiveMode;
            }
            private set
            {
                this.aggressiveMode = true;
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
            string state = String.Empty;
            if (AggressiveMode)
            {
                state = "ON";
            }
            else
            {
                state = "OFF";
            }
            return base.ToString() + Environment.NewLine + $" *Aggressive: {state}";

        }
    }
}
