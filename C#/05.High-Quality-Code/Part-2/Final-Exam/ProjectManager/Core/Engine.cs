namespace ProjectManager.Core
{
    using Bytes2you.Validation;
    using Common;
    using Common.Exceptions;
    using Providers.Contracts;
    using System;
    using ProjectManager.Common.Contracts;

    public class Engine
    {
        private IFileLogger logger;
        private ICommandProcessor processor;
        private IReader reader;
        private IWriter writer;

        public Engine(IFileLogger logger, ICommandProcessor processor, IReader reader, IWriter writer)
        {
            Guard.WhenArgument(logger, "Engine Logger provider").IsNull().Throw();
            Guard.WhenArgument(processor, "Engine Processor provider").IsNull().Throw();

            this.logger = logger;
            this.processor = processor;
            this.reader = reader;
            this.writer = writer;
        }

        public void Start()
        {
            while (true)
            {
                string command = this.reader.ReadLine();

                if (command.ToLower() == "exit")
                {
                   this.writer.WriteLine("Program terminated.");
                    break;
                }

                try
                {
                    var executionResult = this.processor.ProcessCommand(command);
                    this.writer.WriteLine(executionResult);
                }
                catch (UserValidationException ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine("Opps, something happened. :");
                    this.logger.ThrowErrorMessage(ex.Message);
                }
            }
        }
    }
}
