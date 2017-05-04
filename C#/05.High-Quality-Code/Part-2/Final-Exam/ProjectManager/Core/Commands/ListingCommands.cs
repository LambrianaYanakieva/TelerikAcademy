namespace ProjectManager.Commands
{
    using Bytes2you.Validation;
    using Common.Exceptions;
    using Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class ListProjectsCommand : ICommand
    {
        private Database database;

        public ListProjectsCommand(Database database)
        {           
            Guard.WhenArgument(database, "ListProjectsCommand Database").IsNull().Throw();

            this.database = database;
        }

        public string Execute(List<string> parameters)
        {
            if (parameters.Count != 0)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (parameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }

            return string.Join(Environment.NewLine, this.database.Projects);
        }
    }
}
