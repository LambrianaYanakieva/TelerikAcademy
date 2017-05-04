namespace Pesho.Core.Providers
{
    using ProjectManager.Core.Providers.Contracts;
    using System;

    public class ConsoleWriterProvider : IWriter
    {
        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
