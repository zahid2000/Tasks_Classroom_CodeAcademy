using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyContact.Services.Abstract;

namespace MyContact.Core.Utilities.Logger
{
    public class LoggerService : ILoggerService
    {
        public void Log(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}