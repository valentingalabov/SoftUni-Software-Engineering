using MortalEngines.Core.Contracts;
using MortalEngines.Entities;
using MortalEngines.Entities.Contracts;
using MortalEngines.IO.Contracts;
using System;
using System.Linq;
using System.Text;

namespace MortalEngines.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            string currentCommand = Console.ReadLine();
            MachinesManager machinesManager = new MachinesManager();
            IWriter writer = new Writer();

            StringBuilder sb = new StringBuilder();

            while (currentCommand != "Quit")
            {
                string[] args = currentCommand.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = args[0];
                string name = args[1];

                try
                {
                    if (command == "HirePilot")
                    {
                       sb.AppendLine(machinesManager.HirePilot(name));
                    }
                    else if (command == "PilotReport")
                    {
                        sb.AppendLine(machinesManager.PilotReport(name));
                    }
                    else if (command == "ManufactureTank")
                    {
                        double attack = double.Parse(args[2]);
                        double defense = double.Parse(args[3]);

                        sb.AppendLine(machinesManager.ManufactureTank(name, attack, defense));
                    }
                    else if (command == "ManufactureFighter")
                    {
                        double attack = double.Parse(args[2]);
                        double defense = double.Parse(args[3]);

                        sb.AppendLine(machinesManager.ManufactureFighter(name, attack, defense));

                    }

                    else if (command == "MachineReport")
                    {
                        sb.AppendLine(machinesManager.MachineReport(name));
                    }
                    else if (command == "AggressiveMode")
                    {
                        sb.AppendLine(machinesManager.ToggleFighterAggressiveMode(name));
                    }
                    else if (command == "DefenseMode")
                    {
                        sb.AppendLine(machinesManager.ToggleTankDefenseMode(name));
                    }
                    else if (command == "Engage")
                    {
                        string machineName = args[2];
                        sb.AppendLine(machinesManager.EngageMachine(name, machineName));
                    }
                    else if (command == "Attack")
                    {
                        string deffendingMachineName = args[2];
                        sb.AppendLine(machinesManager.AttackMachines(name, deffendingMachineName));

                    }
                }
                catch (ArgumentNullException ex)
                {

                    Console.WriteLine($"Error: " + ex.ParamName);
                }

                currentCommand = Console.ReadLine();
            }

            writer.Write(sb.ToString().TrimEnd());
        }
    }
}
