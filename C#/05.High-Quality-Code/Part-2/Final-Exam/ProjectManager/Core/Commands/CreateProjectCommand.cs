namespace ProjectManager.Core.Commands
{
    using Bytes2you.Validation;
    using Common.Exceptions;
    using Data;
    using Models;
    using ProjectManager.Commands;
    using System.Collections.Generic;
    using System.Linq;

    public class CreateProjectCommand : ICommand
    {
        private Database database;
        private ModelsFactory modelsFactory;

        private string name;
        private string startingDate;
        private string endingDate;
        private string state;

        public CreateProjectCommand(Database database, ModelsFactory factory)
        {
            Guard.WhenArgument(database, "CreateProjectCommand Database").IsNull().Throw();
            Guard.WhenArgument(
                    factory, "CreateProjectCommand ModelsFactory")
                .IsNull().Throw();

            this.database = database;
            this.modelsFactory = factory;
        }

        public string Execute(List<string> parameters)
        {
            this.name = parameters[0];
            this.startingDate = parameters[1];
            this.endingDate = parameters[2];
            this.state = parameters[3];

            if (parameters.Count != 4)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (parameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }

            if (this.database.Projects.Any(x => x.Name == parameters[0]))
            {
                throw new UserValidationException("A project with that name already exists!");
            }

            Project project = this.modelsFactory.CreateProject(this.name, this.startingDate, this.endingDate, this.state);

            this.database.Projects.Add(project);

            return "Successfully created a new project!";
        }
    }
}
