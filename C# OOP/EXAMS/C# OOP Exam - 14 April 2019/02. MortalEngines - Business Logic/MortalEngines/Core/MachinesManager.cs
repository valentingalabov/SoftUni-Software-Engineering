namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;
    using MortalEngines.Entities.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        private IList<IPilot> pilots;
        private IList<IMachine> machines;
        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }
        public string HirePilot(string name)
        {
            if (this.pilots.Any(p => p.Name == name))
            {
                return $"Pilot {name} is hired already";
            }

            IPilot pilot = new Pilot(name);

            pilots.Add(pilot);

            return $"Pilot {name} hired";
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(m => m.Name == name))
            {
                return $"Machine {name} is manufactured already";
            }

            IMachine tank = new Tank(name, attackPoints, defensePoints);

            this.machines.Add(tank);
            return $"Tank {name} manufactured - attack: {tank.AttackPoints:F2}; defense: {tank.DefensePoints:F2}";
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(m => m.Name == name))
            {
                return $"Machine {name} is manufactured already";
            }

            IMachine fighter = new Fighter(name, attackPoints, defensePoints);

            this.machines.Add(fighter);

            return $"Fighter {fighter.Name} manufactured - attack: {fighter.AttackPoints:F2}; defense: {fighter.DefensePoints:F2}; aggressive: ON";


        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            IPilot pilot = this.pilots.FirstOrDefault(p => p.Name == selectedPilotName);

            if (pilot == null)
            {
                return $"Pilot {selectedPilotName} could not be found";
            }
            IMachine machine = this.machines.FirstOrDefault(m => m.Name == selectedMachineName);

            if (machine == null)
            {
                return $"Machine {selectedMachineName} could not be found";
            }

            if (machine.Pilot != null)
            {
                return $"Machine {selectedMachineName} is already occupied";
            }

            pilot.AddMachine(machine);

            machine.Pilot = pilot;

            return $"Pilot {selectedPilotName} engaged machine {selectedMachineName}";


        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            IMachine attackMachine = this.machines.FirstOrDefault(m => m.Name == attackingMachineName);

            if (attackMachine == null)
            {
                return $"Machine {attackingMachineName} could not be found";
            }

            IMachine defendMachine = this.machines.FirstOrDefault(m => m.Name == defendingMachineName);

            if (defendMachine == null)
            {
                return $"Machine {defendingMachineName} could not be found";
            }

            if (attackMachine.HealthPoints <= 0)
            {
                return $"Dead machine {attackingMachineName} cannot attack or be attacked";
            }

            if (defendMachine.HealthPoints <= 0)
            {
                return $"Dead machine {defendingMachineName} cannot attack or be attacked";
            }


            attackMachine.Attack(defendMachine);
            return $"Machine {defendingMachineName} was attacked by machine {attackingMachineName} - current health: {defendMachine.HealthPoints:F2}";

        }

        public string PilotReport(string pilotReporting)
        {
            IPilot pilotToReport = this.pilots.FirstOrDefault(p => p.Name == pilotReporting);

            if (pilotReporting == null)
            {
                return $"Pilot {pilotReporting} could not be found";
            }

            return pilotToReport.Report();

        }

        public string MachineReport(string machineName)
        {
            IMachine machineToReport = this.machines.FirstOrDefault(m => m.Name == machineName);
            if (machineToReport == null)
            {
                return $"Machine {machineName} could not be found";
            }

            return machineToReport.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            IMachine machine = this.machines.FirstOrDefault(m => m.Name == fighterName);

            if (machine == null)
            {
                return $"Machine {fighterName} could not be found";
            }

            IFighter fighter = (IFighter)machine;

            fighter.ToggleAggressiveMode();

            return $"Fighter {fighterName} toggled aggressive mode";

        }

        public string ToggleTankDefenseMode(string tankName)
        {
            IMachine machine = this.machines.FirstOrDefault(m => m.Name == tankName);
            if (machine == null)
            {
                return $"Machine {tankName} could not be found";
            }

            ITank tank = (ITank)machine;

            tank.ToggleDefenseMode();

            return $"Tank {tankName} toggled defense mode";
        }
    }
}