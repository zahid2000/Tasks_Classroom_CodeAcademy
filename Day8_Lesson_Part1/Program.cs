
using Day8_Lesson_Part1.Services;

internal class Program
{
    public delegate void DefaultLogManager(string message);
    public delegate void LowLogManager(string message);
    public delegate void HighLogManager(string message);
    static void Main(string[] args)
    {
        SetLogger setLogger = new SetLogger();
        XMLLogger xMLLogger = new XMLLogger();
        SMSLogger sMSLogger = new SMSLogger();
        SQLLogger sQLLogger = new SQLLogger();
        MailLogger mailLogger = new MailLogger();
        PushNotificationLogger pushNotificationLogger = new PushNotificationLogger();

        DefaultLogManager defaultLogManager = new DefaultLogManager(setLogger.SetLog);
        defaultLogManager.Invoke("Error message");

        LowLogManager lowLogManager = new LowLogManager(defaultLogManager);
        lowLogManager += sMSLogger.SetLog;
        lowLogManager += mailLogger.SetLog;
        lowLogManager.Invoke("Error message"); 
    }
}
