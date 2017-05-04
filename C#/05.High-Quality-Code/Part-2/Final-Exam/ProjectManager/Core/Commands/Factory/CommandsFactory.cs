using ProjectManager.Core.Commands;

namespace ProjectManager.Commands.Factory
{
    using Common.Exceptions;
    using Data;
    using Models;
    using System;

    public class CommandsFactory
    {
        private ModelsFactory modelsFactory;
        private Database database;

        public CommandsFactory(Database database, ModelsFactory modelsFactory)
        {
            this.database = database;
            this.modelsFactory = modelsFactory;
        }

        public ICommand CreateCommandFromString(string commandName)
        {
            var command = this.BuildCommand(commandName);

            switch (command)
            {
                case "createproject":
                    return new CreateProjectCommand(this.database, this.modelsFactory);
                case "createtask":
                    return new CreateTaskCommand(this.database, this.modelsFactory);
                case "listprojects":
                    return new ListProjectsCommand(this.database);
                case "createuser":
                    return new CreateUserCommand(this.database, this.modelsFactory);
                default:
                    throw new UserValidationException("The passed command is not valid!");
            }
        }  

        private string BuildCommand(string parameters)
        {
            var command = string.Empty;

            var end = DateTime.Now + TimeSpan.FromSeconds(1);

            while (DateTime.Now < end)
            {              
            }

            for (int i = 0; i < parameters.Length; i++)
            {
                command += parameters[i].ToString().ToLower();
            }
            
            return command;
        }    
    }
}