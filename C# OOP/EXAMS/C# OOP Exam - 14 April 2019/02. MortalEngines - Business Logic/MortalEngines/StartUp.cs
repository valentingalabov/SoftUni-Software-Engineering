using MortalEngines.Core;
using MortalEngines.Core.Contracts;
using System;

namespace MortalEngines
{
    public class StartUp
    {
        public static void Main()
        {
            IMachinesManager machinesManager = new MachinesManager();

            string command = Console.ReadLine();


            while (command != "Quit")
            {
                string[] tokens = command.Split(' ');
                string currentCommand = tokens[0];

                if (currentCommand == "HirePilot")
                {
                    Console.WriteLine(machinesManager.HirePilot(tokens[1]));
                }

                else if (currentCommand == "PilotReport")
                {
                    Console.WriteLine(machinesManager.PilotReport(tokens[1]));
                }
                else if (currentCommand == "ManufactureTank")
                {
                    Console.WriteLine(machinesManager.ManufactureTank(tokens[1], double.Parse(tokens[2]), double.Parse(tokens[3])));
                }

                else if (currentCommand == "ManufactureFighter")
                {
                    Console.WriteLine(machinesManager.ManufactureFighter(tokens[1], double.Parse(tokens[2]), double.Parse(tokens[3])));
                }
                else if (currentCommand == "MachineReport")
                {
                    Console.WriteLine(machinesManager.MachineReport(tokens[1]));
                }
                else if (currentCommand == "AggressiveMode")
                {
                    Console.WriteLine(machinesManager.ToggleFighterAggressiveMode(tokens[1]));
                }
                else if (currentCommand == "DefenseMode ")
                {
                    Console.WriteLine(machinesManager.ToggleTankDefenseMode(tokens[1]));
                }
                else if (currentCommand == "Engage")
                {
                    Console.WriteLine(machinesManager.EngageMachine(tokens[1], tokens[2]));
                }
                else if (currentCommand == "Attack")
                {
                    Console.WriteLine(machinesManager.AttackMachines(tokens[1], tokens[2]));
                }


                command = Console.ReadLine();
            }



        }
    }
}