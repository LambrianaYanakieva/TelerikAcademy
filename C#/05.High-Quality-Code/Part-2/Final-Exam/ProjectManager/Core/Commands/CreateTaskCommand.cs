namespace ProjectManager.Core.Commands
{
    using Bytes2you.Validation;
    using Common.Exceptions;
    using Data;
    using Models;
    using ProjectManager.Commands;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class CreateTaskCommand : ICommand
    {
        private const string InvalidParametersCount = "Invalid command parameters count!";
        private const string InvalidParametersValue = "Some of the passed parameters are empty!";
        private const string TaskCreated = "Successfully created a new task!";

        private IProject project;

        private Database database;
        private ModelsFactory modelsFactory;      
        private User owner;

        private string name;
        private string state;

        public CreateTaskCommand(Database database, ModelsFactory factory)
        {
            Guard.WhenArgument(database, "CreateTaskCommand Database").IsNull().Throw();
            Guard.WhenArgument(
                    factory, "CreateTaskCommand ModelsFactory")
                .IsNull().Throw();

            this.database = database;
            this.modelsFactory = factory;
        }
 
        public string Execute(List<string> parameters)
        {
            this.project = this.database.Projects[int.Parse(parameters[0])];
            this.owner = this.project.Users[int.Parse(parameters[1])];
            this.name = parameters[2];
            this.state = parameters[3];

            if (parameters.Count != 4)
            {
                throw new UserValidationException(InvalidParametersCount);
            }

            if (parameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException(InvalidParametersValue);
            }

            Task task = this.modelsFactory.CreateTask(this.owner, this.name, this.state);

            this.project.Tasks.Add(task);

            return TaskCreated;
        }
    }
}
