using System;

using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities.Models
{
    public class Fighter : BaseMachine, IFighter
    {
        private const int INITIAL_HEALTH_POINTS = 200;
        private const int ATTACK_POINTS_TO_INCREASE = 50;
        private const int DEFENSE_POINTS_TO_DECREASE = 25;

        public Fighter(string name, double attackPoints, double defensePoints)
            : base(name,
                  attackPoints + ATTACK_POINTS_TO_INCREASE,
                  defensePoints - DEFENSE_POINTS_TO_DECREASE,
                  INITIAL_HEALTH_POINTS)
        {
            this.AggressiveMode = true;
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode == false)
            {
                this.AggressiveMode = true;

                this.AttackPoints += ATTACK_POINTS_TO_INCREASE;
                this.DefensePoints -= DEFENSE_POINTS_TO_DECREASE;
            }
            else
            {
                this.AggressiveMode = false;

                this.AttackPoints -= ATTACK_POINTS_TO_INCREASE;
                this.DefensePoints += DEFENSE_POINTS_TO_DECREASE;
            }
        }

        public override string ToString()
        {
            string result = string.Empty;

            if (this.AggressiveMode == true)
            {
                result = base.ToString() + Environment.NewLine + " *Aggressive: ON";
            }
            else
            {
                result = base.ToString() + Environment.NewLine + " *Aggressive: OFF";
            }

            return result;
        }
    }
}