using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Tank : BaseMachine, ITank
    {



        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints -= 40, defensePoints += 30, 100)
        {


        }

        public bool DefenseMode
        {
            get
            {
                return this.DefenseMode;
            }
            private set
            {
                this.DefenseMode = true;
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
            else
            {
                this.DefenseMode = true;
                AttackPoints -= 40;
                DefensePoints += 30;
            }

        }

        public override string ToString()
        {
            if (DefenseMode)
            {
                return base.ToString() + Environment.NewLine + $" *Defense: ON";
            }
            else
            {
                return base.ToString() + Environment.NewLine + $" *Defense: OFF";
            }

        }
    }
}