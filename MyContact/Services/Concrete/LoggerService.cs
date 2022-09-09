using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyContact.Services.Abstract;

namespace MyContact.Services.Concrete
{
    public class LoggerService : ILoggerService
    {
        public void Log(string message)
        {
            System.Console.WriteLine(message);
        }
    }
}