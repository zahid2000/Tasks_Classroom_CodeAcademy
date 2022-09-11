namespace MyContact.Services.Abstract
{
    public interface ILoggerService
    {
        void Log(string message);
        void Log(string message, ConsoleColor color);
    }
}