using Pesho.Core.Providers;
using ProjectManager.Core.Providers.Contracts;

namespace ProjectManager
{
    using Commands.Factory;
    using Common;
    using Core;
    using Core.Providers;
    using Data;
    using Models;

    public static class Startup
    {
        public static void Main()
        {
            FileLogger fileLogger = new FileLogger();
            Database database = new Database();
            ModelsFactory modelsFactory = new ModelsFactory();
            CommandsFactory commandsFactory = new CommandsFactory(database, modelsFactory);
            CommandProcessor commandProcessor = new CommandProcessor(commandsFactory);

            IWriter writer = new ConsoleWriterProvider();
            IReader reader = new ConsoleReaderProvider();

            Engine engine = new Engine(fileLogger, commandProcessor, reader, writer);
            EngineProvider provider = new EngineProvider(engine);

            provider.StartEngine();
        }
    }
}
