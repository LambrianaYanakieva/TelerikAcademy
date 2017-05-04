namespace ProjectManager.Common.Contracts
{
   public interface IFileLogger
    {
        void GetInformation(object msg);

        void ThrowErrorMessage(object msg);

        void ThrowFatalMessage(object msg);
    }
}
