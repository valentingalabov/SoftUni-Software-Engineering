using LoggerExercise.Core;
using LoggerExercise.Core.Contracts;

namespace LoggerExerciseExercise
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ICommandInterpreter commandInterpreter = new CommandInterpreter();

            Engine engine = new Engine(commandInterpreter);
            engine.Run();

        }
    }
}
