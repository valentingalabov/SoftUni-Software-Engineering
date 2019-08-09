using MortalEngines.Entities.Contracts;
using MortalEngines.Entities.Models;
using System;

namespace MortalEngines.Entities
{
    public class Tank : BaseMachine, ITank
    {
        private const double INITIAL_HP = 100;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, INITIAL_HP)
        {
            this.ToggleDefenseMode();
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode == false)
            {
                this.DefenseMode = true;
                this.AttackPoints -= 40;
                this.DefensePoints += 30;
            }
            else
            {
                this.DefenseMode = false;
                this.AttackPoints += 40;
                this.DefensePoints -= 30;
            }
        }

        public override string ToString()
        {
            string modePosition = this.DefenseMode ? "ON" : "OFF";

            return base.ToString() + Environment.NewLine +
                $" *Defense: {modePosition}";
        }
    }
}
