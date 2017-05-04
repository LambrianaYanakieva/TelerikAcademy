namespace ProjectManager.Models
{
    using Common.Exceptions;
    using Common.Providers;
    using System;

    public class ModelsFactory
    {
        private readonly Validator validator = new Validator();

        private DateTime starting;
        private DateTime end;

        private bool startingDateSuccessful;
        private bool endingDateSuccessful;

        public Project CreateProject(string name, string startingDate, string endingDate, string state)
        {           
            this.startingDateSuccessful = DateTime.TryParse(startingDate, out this.starting);
            this.endingDateSuccessful = DateTime.TryParse(endingDate, out this.end);

            if (!this.startingDateSuccessful)
            {
                throw new UserValidationException("Failed to parse the passed starting date!");
            }

            if (!this.endingDateSuccessful)
            {
                throw new UserValidationException("Failed to parse the passed ending date!");
            }

            Project project = new Project(name, this.starting, this.end, state);
            this.validator.Validate(project);

            return project;
        }

        public Task CreateTask(User owner, string name, string state)
        {
            Task task = new Task(name, owner, state);
            this.validator.Validate(task);

            return task;
        }
      
        public User CreateUser(string username, string email)
        {
            User user = new User(email, username);
            this.validator.Validate(user);

            return user;
        }       
    }
}