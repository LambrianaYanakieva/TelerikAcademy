namespace ProjectManager.Common
{
    using Contracts;
    using log4net;

    public class FileLogger : IFileLogger
    {
        private ILog logger;

        public FileLogger()
        {
            this.logger = LogManager.GetLogger(typeof(FileLogger));
        }

        public void GetInformation(object msg)
        {
            this.logger.Info(msg);
        }  
              
        public void ThrowErrorMessage(object msg)
        {
            this.logger.Error(msg);
        }  
              
        public void ThrowFatalMessage(object msg)
        {
            this.logger.Fatal(msg);
        }
    }
}