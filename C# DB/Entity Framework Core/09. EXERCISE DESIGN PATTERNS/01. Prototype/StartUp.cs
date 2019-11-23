using System;

namespace _01._Prototype
{
    class StartUp
    {
        static void Main(string[] args)
        {
            SandwichMenu sandwichMenu = new SandwichMenu();

            sandwichMenu["BLT"] = new Sandwich("Wheat", "Bacon", "", "Lettuce, Tomato");
            sandwichMenu["PB&J"] = new Sandwich("White", "", "", "Penaut Butter, Jelly");
            sandwichMenu["Turkey"] = new Sandwich("Rye", "Turkey", "Swiss", "Lettuce, Onion, Tomato");


            Sandwich sandwich1 = sandwichMenu["BLT"].Clone() as Sandwich;

        }
    }
}
