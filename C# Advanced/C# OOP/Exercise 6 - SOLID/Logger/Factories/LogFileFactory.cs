namespace Exercise_6___SOLID.Factories
{
    using Contracts;
    using Models.Contracts;
    using Models.Files;

    public class LogFileFactory : ILogFileFactory
    {
        public IFile GetLogFile()
            => new LogFile();
    }
}