using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8_Lesson_Part1.Services;

public interface ILogger
{
    void SetLog(string message);
}
public class SetLogger : ILogger { public void SetLog(string message) { Console.WriteLine($"SetLogger -> {message} "); } }
public class SMSLogger : ILogger { public void SetLog(string message) { Console.WriteLine($"SMSLogger -> {message} "); } }
public class XMLLogger : ILogger { public void SetLog(string message) { Console.WriteLine($"XMLLogger -> {message} "); } }
public class SQLLogger : ILogger { public void SetLog(string message) { Console.WriteLine($"SQLLogger -> {message} "); } }
public class MailLogger : ILogger { public void SetLog(string message) { Console.WriteLine($"MailLogger -> {message} "); } }
public class PushNotificationLogger : ILogger { public void SetLog(string message) { Console.WriteLine($"PushNotificationLogger -> {message} "); } }
