using System;
using System.Text;
using System.Collections.Generic;

using MortalEngines.Common;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities.Models
{
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;

        private BaseMachine()
        {
            this.Targets = new List<string>();
        }

        public BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
            : this()
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.MachineNullOrEmptyException);
                }

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get => this.pilot;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.PilotNullException);
                }

                this.pilot = value;
            }
        }

        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets { get; private set; }

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException(ExceptionMessages.TargetNullException);
            }

            double valueToDecrease = Math.Abs(this.AttackPoints - target.DefensePoints);

            if (target.HealthPoints - valueToDecrease < 0)
            {
                target.HealthPoints = 0;
            }
            else
            {
                target.HealthPoints -= valueToDecrease;
            }

            this.Targets.Add(target.Name);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"- {this.Name}")
                .AppendLine($" *Type: {this.GetType().Name}")
                .AppendLine($" *Health: {this.HealthPoints:F2}")
                .AppendLine($" *Attack: {this.AttackPoints:F2}")
                .AppendLine($" *Defense: {this.DefensePoints:F2}");

            if (this.Targets.Count == 0)
            {
                sb.AppendLine(" *Targets: None");
            }
            else
            {
                sb.AppendLine($" *Targets: {string.Join(",", this.Targets)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}