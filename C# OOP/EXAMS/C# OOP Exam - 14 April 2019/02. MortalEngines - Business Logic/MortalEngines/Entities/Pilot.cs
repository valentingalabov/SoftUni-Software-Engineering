using System;
using System.Text;
using System.Collections.Generic;

using MortalEngines.Common;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities.Models
{
    public class Pilot : IPilot
    {
        private string name;
        private readonly List<IMachine> machines;

        private Pilot()
        {
            this.machines = new List<IMachine>();
        }

        public Pilot(string name)
            : this()
        {
            this.Name = name;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.PilotNameNullOrEmptyException);
                }

                this.name = value;
            }
        }

        public IReadOnlyCollection<IMachine> Machines
        {
            get => this.machines.AsReadOnly();
        }

        public void AddMachine(IMachine machine)
        {
            if (machine == null)
            {
                throw new NullReferenceException(ExceptionMessages.MachineNullAdditionException);
            }

            this.machines.Add(machine);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} - {this.Machines.Count} machines");

            foreach (var machine in this.Machines)
            {
                sb.AppendLine(machine.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}