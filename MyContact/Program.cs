using MyContact.Core.Utilities.Logger;
using MyContact.DataAccess.Abstract;
using MyContact.DataAccess.Concrete.AdoNet;
using MyContact.DataAccess.Concrete.EntityFramework;
using MyContact.Models;
using MyContact.Services.Abstract;
using MyContact.Services.Concrete.Ado.Net;
using MyContact.Services.Concrete.EntityFramework;

ILoggerService loggerService = new LoggerService();
IContactRepository efContactRepository = new ContactRepository();
IContactRepository adoContactRepository = new AdoContactRepository();
IContactService efContactService = new EfContactService(efContactRepository, loggerService);
IContactService adoContactService = new AdoContactService(adoContactRepository, loggerService);

MainMenu:
while (true)
{
    Console.WriteLine("Ado.Net Menu -> (a)\n" +
        "Entity Framework Menu -> (e)\n" +
        "Exit -> (x)");
    string answer = Console.ReadLine();
    Console.WriteLine(new string('-', 100));
    switch (answer.ToLower().Replace(" ", ""))
    {
        case "a":
            AdoNetMenu();
            break;
        case "e":
            EFMenu();
            break;
        case "x":
            goto Exit_MainMenu;
            break;

        default:
            loggerService.Log("LOG : Incorrect simvol", ConsoleColor.Red);
            break;
    }
}
Exit_MainMenu:
loggerService.Log("See you later", ConsoleColor.Yellow);
void AdoNetMenu()
{
    while (true)
    {
        Console.WriteLine(
            "Add a new contact-> (a)\n" +
            "Get all contacts -> (l)\n" +
            "Search contact -> (s)\n" +
            "Delete contact by id ->(d)\n" +
            "Update contact ->(u)\n" +
            "Main menu -> (m)"
        ); System.Console.WriteLine(new string('-', 100));
        string answer = Console.ReadLine();
        System.Console.WriteLine(new string('-', 100));
        switch (answer.ToLower())
        {
            case "a":
                AdoAddContact();
                System.Console.WriteLine(new string('-', 100));
                break;
            case "l":
                AdoGetAllAsync();
                System.Console.WriteLine(new string('-', 100));
                break;
            case "s":
                AdoGet();
                System.Console.WriteLine(new string('-', 100));
                break;
            case "d":
                AdoDelete();
                System.Console.WriteLine(new string('-', 100));
                break;
            case "u":
                AdoUpdateContact();
                System.Console.WriteLine(new string('-', 100));
                break;
            case "m":
                goto Exit_AdoMenu;
            default:
                loggerService.Log("LOG : Incorrect simvol", ConsoleColor.Red);
                break;

        }

    }
Exit_AdoMenu:;
}
void EFMenu()
{
    while (true)
    {
        Console.WriteLine(
            "Add a new contact-> (a)\n" +
            "Get all contacts -> (l)\n" +
            "Search contact -> (s)\n" +
            "Delete contact by id -> (d)\n" +
            "Update contact -> (u)\n" +
            "Back to main menu -> (m)"
        ); System.Console.WriteLine(new string('-', 100));
        string answer = Console.ReadLine();
        System.Console.WriteLine(new string('-', 100));
        switch (answer.ToLower())
        {
            case "a":
                EFAddContact();
                System.Console.WriteLine(new string('-', 100));
                break;
            case "l":
                EFGetAll();
                System.Console.WriteLine(new string('-', 100));
                break;
            case "s":
                EFGet();
                System.Console.WriteLine(new string('-', 100));
                break;
            case "d":
                EFDelete();
                System.Console.WriteLine(new string('-', 100));
                break;
            case "u":
                EFUpdateContact();
                System.Console.WriteLine(new string('-', 100));
                break;
            case "m":
                goto Exit_EFMenu;
            default:
                loggerService.Log("LOG : Incorrect simvol", ConsoleColor.Red);
                break;

        }
    }
Exit_EFMenu:;
}

#region EntityFramework
void EFAddContact()
{
    Console.Clear();
    Contact contact = new Contact();
    Console.WriteLine("Enter name");
    contact.FirstName = Console.ReadLine();
    Console.WriteLine("Enter surname");
    contact.LastName = Console.ReadLine();
    Console.WriteLine("Enter phone");
    contact.Phone = Console.ReadLine();
    Console.WriteLine("Enter email");
    contact.Email = Console.ReadLine();
    Console.WriteLine("Do you want to save? Y/N");
    var answer = Console.ReadLine();
    if (answer.ToLower().Equals("y"))
    {
        efContactService.Add(contact);
    }
    else
    {
        System.Console.WriteLine("Doesn't coreect simvol");
    }
}
void EFGetAll()
{
    Console.Clear();
    List<Contact> contacts = efContactService.GetAll();
    ConsoleList(contacts);
}
void EFGet()
{
    Console.Clear();
    System.Console.WriteLine("By which parameter do you want to search for the contact??\n " +
        " FirstName -> (a),\n" +
        " LastName -> (s),\n" +
        " Phone -> (t),\n" +
        " Mail -> (e)");
    string answer = Console.ReadLine();
    switch (answer.ToLower())
    {
        case "a":
            System.Console.WriteLine("Enter the FirstName");
            string name = Console.ReadLine();
            ConsoleContact(efContactService.GetBy(x => x.FirstName == name));
            break;
        case "s":
            System.Console.WriteLine("Enter the LastName");
            string lastName = Console.ReadLine();
            ConsoleContact(efContactService.GetBy(x => x.LastName == lastName));
            break;
        case "t":
            System.Console.WriteLine("Enter the Phone");
            string phone = Console.ReadLine();
            ConsoleContact(efContactService.GetBy(x => x.Phone == phone));
            break;
        case "e":
            System.Console.WriteLine("Enter the Mail");
            string email = Console.ReadLine();
            ConsoleContact(efContactService.GetBy(x => x.Email == email));
            break;
        default:
            System.Console.WriteLine("Incorrect simvol");
            break;
    }
}
void EFDelete()
{
    Console.WriteLine("Enter the Contact Id which you want to update");
    int answer = int.Parse(Console.ReadLine());
    Contact deletedContact = efContactService.GetBy(x => x.Id == answer);
    if (deletedContact == null) System.Console.WriteLine("This Contact is not exists");
    else efContactService.Delete(deletedContact);
}
void EFUpdateContact()
{
    Console.Clear();
    Contact contact = new Contact();
    Console.WriteLine("Enter the Contact Id which you want to update");
    contact.Id = int.Parse(Console.ReadLine());
    Console.WriteLine("Enter the Firstname");
    contact.FirstName = Console.ReadLine();
    Console.WriteLine("Enter the Lastname");
    contact.LastName = Console.ReadLine();
    Console.WriteLine("Enter the Phone");
    contact.Phone = Console.ReadLine();
    Console.WriteLine("Enter the Email");
    contact.Email = Console.ReadLine();
    Console.WriteLine("Are you sure? Y/N");
    string answer = Console.ReadLine();
    if (answer.ToLower().Equals("y"))
    {
        efContactService.Update(contact);
    }
    else
    {
        System.Console.WriteLine("Does Not Updated");
    }
}
#endregion

#region AdoNet
async void AdoGetAllAsync()
{
    Console.Clear();
    ConsoleList(await adoContactService.GetAllAsync());
}
void AdoAddContact()
{
    Console.Clear();
    Contact contact = new Contact();
    Console.WriteLine("Enter name");
    contact.FirstName = Console.ReadLine();
    Console.WriteLine("Enter surname");
    contact.LastName = Console.ReadLine();
    Console.WriteLine("Enter phone");
    contact.Phone = Console.ReadLine();
    Console.WriteLine("Enter email");
    contact.Email = Console.ReadLine();
    Console.WriteLine("Do you want to save? Y/N");
    var answer = Console.ReadLine();
    if (answer.ToLower().Equals("y"))
    {
        adoContactService.Add(contact);
    }
    else
    {
        System.Console.WriteLine("Doesn't coreect simvol");
    }
}
void AdoUpdateContact()
{
    Console.Clear();
    Contact contact = new Contact();
    Console.WriteLine("Enter the Contact Id which you want to update");
    contact.Id = int.Parse(Console.ReadLine());
    Console.WriteLine("Enter the Firstname");
    contact.FirstName = Console.ReadLine();
    Console.WriteLine("Enter the Lastname");
    contact.LastName = Console.ReadLine();
    Console.WriteLine("Enter the Phone");
    contact.Phone = Console.ReadLine();
    Console.WriteLine("Enter the Email");
    contact.Email = Console.ReadLine();
    Console.WriteLine("Are you sure? Y/N");
    var answer = Console.ReadLine();
    if (answer.ToLower().Equals("y"))
    {
        adoContactService.Update(contact);
    }
    else
    {
        System.Console.WriteLine("Does Not Updated");
    }
}
void AdoDelete()
{
    Console.WriteLine("Enter the Contact Id which you want to delete");
    Contact contact=new Contact();
    contact.Id = int.Parse(Console.ReadLine());
    Contact deletedContact = adoContactService.Get(contact);
    if (deletedContact == null) System.Console.WriteLine("This Contact is not exists");
    else adoContactService.Delete(deletedContact);
}
void AdoGet()
{
    Console.Clear();
    Console.WriteLine("Enter the Contact Id which you want to search");
    Contact contact = new Contact();
    contact.Id = int.Parse(Console.ReadLine());
    ConsoleContact(adoContactRepository.Get(contact));
}
#endregion
void ConsoleList(List<Contact> contacts)
{

    Console.WriteLine(new String('-', 40) + "Contacts" + new String('-', 40) + "\n\n");
    System.Console.WriteLine("  {0,-15}{1,-25}{2,-20}{3,-20}{4,-35}", "[Id]", "[FirstName]", "[LastName]", "[Phone]", "[Email]");
    foreach (Contact contact in contacts)
    {
        System.Console.WriteLine("   {0,-15}{1,-25}{2,-20}{3,-20}{4,-35}", contact.Id, contact.FirstName, contact.LastName, contact.Phone, contact.Email);
    }
}
void ConsoleContact(Contact contact)
{

    Console.WriteLine(new String('-', 40) + "Contact" + new String('-', 40) + "\n\n");
    System.Console.WriteLine("  {0,-15}{1,-25}{2,-20}{3,-20}{4,-35}", "[Id]", "[FirstName]", "[LastName]", "[Phone]", "[Email]");
    System.Console.WriteLine("  {0,-15}{1,-25}{2,-20}{3,-20}{4,-35}", contact.Id, contact.FirstName, contact.LastName, contact.Phone, contact.Email);

}