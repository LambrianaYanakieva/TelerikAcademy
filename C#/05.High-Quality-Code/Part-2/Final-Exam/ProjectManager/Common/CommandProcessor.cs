namespace ProjectManager.Common
{
    using System;
    using System.Linq;
    using Commands;
    using Commands.Factory;
    using Contracts;

    public class CommandProcessor : ICommandProcessor
    {
        private CommandsFactory factory;

        public CommandProcessor(CommandsFactory factory)
        {
            this.factory = factory;
        }

        public string ProcessCommand(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                throw new Exceptions.UserValidationException("No command has been provided!");
            }

            if (command.Split(' ').Count() > 10)
            {
                throw new ArgumentException();
            }

            ICommand parsedCommand = this.factory
                .CreateCommandFromString(command.Split(' ')[0]);

            string result = parsedCommand
                .Execute(command.Split(' ')
                .Skip(1)
                .ToList());

            return result;
        }
    }
}
