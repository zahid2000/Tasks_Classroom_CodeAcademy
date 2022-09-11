namespace MyContact.Core.Constants;
public static class Messages
{
    public static string Added = "LOG : Added";
    public static string Deleted = "LOG : Deleted";
    public static string Updated = "LOG : Updated";
    public static string Listed = "LOG : Listed";
    public static string NotFound = "LOG : Not Found";
    public static string NotValidEmail = "LOG : This is not valid Email";
    public static string NotValidPhone = "LOG : This is not valid Phone";
}
public static class ConnectionString
{
    public static string AdoNetConnectionString = "server=DESKTOP-QBQM5QA\\SQLEXPRESS;database=MyContactDb;Trusted_Connection=true;";
    public static string EFConnectionString = "server=DESKTOP-QBQM5QA\\SQLEXPRESS;database=MyContactDb;Trusted_Connection=true;";
}