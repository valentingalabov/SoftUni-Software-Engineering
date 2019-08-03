using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Tank : BaseMachine, ITank
    {

        private bool defenseMode;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints -= 40, defensePoints += 30, 100)
        {


        }

        public bool DefenseMode
        {
            get
            {
                return this.defenseMode;
            }
            protected set
            {
                this.defenseMode = true;
            }
        }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode)
            {
                this.DefenseMode = false;
                AttackPoints += 40;
                DefensePoints -= 30;
            }
            else if (this.DefenseMode == false)
            {
                this.DefenseMode = true;
                AttackPoints -= 40;
                DefensePoints += 30;
            }

        }

        public override string ToString()
        {
            string state = String.Empty;
            state = DefenseMode ? "ON" : "OFF";

            return base.ToString() + Environment.NewLine + $" *Defense: {state}";

        }
    }
}