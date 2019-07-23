using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string COMMAND_POSTFIX = "Command";

        public string Read(string inputLine)
        {
            string[] cmdTokens = inputLine
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string commandName = cmdTokens[0] + COMMAND_POSTFIX;

            string[] commandArgs = cmdTokens
                .Skip(1)
                .ToArray();

            Assembly assembly = Assembly
                .GetCallingAssembly();

            Type[] types = assembly
                .GetTypes();

            Type typeToCreate = types
                .FirstOrDefault(t => t.Name == commandName);

            if (typeToCreate == null)
            {
                throw new InvalidOperationException("Invalid Command Type!");
            }

            Object instance = Activator.CreateInstance(typeToCreate);

            ICommand command = (ICommand)instance;

            string result = command.Execute(commandArgs);

            return result;


        }
    }
}
