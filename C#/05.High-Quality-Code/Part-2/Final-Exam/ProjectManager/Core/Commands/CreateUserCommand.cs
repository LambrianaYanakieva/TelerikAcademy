namespace ProjectManager.Core.Commands
{
    using Bytes2you.Validation;
    using Common.Exceptions;
    using Data;
    using Models;
    using ProjectManager.Commands;
    using System.Collections.Generic;
    using System.Linq;

    public class CreateUserCommand : ICommand
    {
        private Database database;
        private ModelsFactory modelsFactory;

        public CreateUserCommand(Database database, ModelsFactory factory)
        {
            Guard.WhenArgument(database, "CreateUserCommand Database").IsNull().Throw();
            Guard.WhenArgument(
                    factory, "CreateUserCommand ModelsFactory")
                .IsNull().Throw();

            this.database = database;
            this.modelsFactory = factory;
        }

        public string Execute(List<string> parameters)
        {
            if (parameters.Count != 3)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (parameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }

            if (this.database.Projects[int.Parse(parameters[0])].Users.Any() &&
                this.database.Projects[int.Parse(parameters[0])].Users.Any(x => x.Username == parameters[1]))
            {
                throw new UserValidationException("A user with that username already exists!");
            }

            this.database
                .Projects[int.Parse(parameters[0])]
                .Users
                .Add(this.modelsFactory.CreateUser(parameters[1], parameters[2]));

            return "Successfully created a new user!";
        }
    }
}
