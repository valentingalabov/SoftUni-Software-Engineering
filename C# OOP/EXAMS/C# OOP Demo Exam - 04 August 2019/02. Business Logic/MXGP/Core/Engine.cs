using MXGP.Core.Contracts;
using System;

namespace MXGP.Core
{
    public class Engine : IEngine
    {
        private IChampionshipController championshipController;
        public Engine()
        {
            this.championshipController = new ChampionshipController();
        }

        public void Run()
        {
            while (true)
            {
                string[] inputInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = inputInfo[0];

                if (command=="End")
                {
                    break;
                }

                else if (command == "CreateRider")
                {
                    string name = inputInfo[1];

                    Console.WriteLine(championshipController.CreateRider(name)); 
                }

                else if (command == "CreateMotorcycle")
                {
                    string type = inputInfo[1];
                    string model = inputInfo[2];
                    int horsepower = int.Parse(inputInfo[3]);


                    Console.WriteLine(championshipController.CreateMotorcycle(type,model,horsepower));
                }
               else if (command == "AddMotorcycleToRider")
                {
                    string riderName = inputInfo[1];
                    string motorcycleName = inputInfo[2];


                    Console.WriteLine(championshipController.AddMotorcycleToRider(riderName,motorcycleName));
                }

                else if (command == "AddRiderToRace")
                {
                    string raceName = inputInfo[1];
                    string riderName = inputInfo[2];


                    Console.WriteLine(championshipController.AddRiderToRace(raceName, riderName));
                }

                else if (command == "CreateRace")
                {
                    string name = inputInfo[1];
                    int laps =int.Parse(inputInfo[2]);


                    Console.WriteLine(championshipController.CreateRace(name, laps));
                }

                else if (command == "StartRace")
                {
                    string name = inputInfo[1];



                    Console.WriteLine(championshipController.StartRace(name));
                }

            }
        }
    }
}