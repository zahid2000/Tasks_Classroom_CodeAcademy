using MyContact.DataAccess.Abstract;
using MyContact.DataAccess.Concrete;
using MyContact.Models;
using MyContact.Services.Abstract;
using MyContact.Services.Concrete;

ILoggerService loggerService = new LoggerService();
IContactRepository contactRepository = new ContactRepository();
IContactService contactService = new ContactService(contactRepository, loggerService);

while (true)
{
    Console.WriteLine(
        "Add a new contact-> (a)\n" +
        "Get all contacts -> (l)\n" +
        "Search contact -> (s)\n" +
        "Delete contact by id ->(d)\n" +
        "Update contact ->(u)"
    ); System.Console.WriteLine(new string('-', 100));
    string answer = Console.ReadLine();
    System.Console.WriteLine(new string('-', 100));
    switch (answer.ToLower())
    {
        case "a":
            AddContact();
            System.Console.WriteLine(new string('-', 100));
            break;
        case "l":
            GetAll();
            System.Console.WriteLine(new string('-', 100));
            break;
        case "s":
            Get();
            System.Console.WriteLine(new string('-', 100));
            break;
        case "d":
            Delete();
            System.Console.WriteLine(new string('-', 100));
            break;
        case "u":
            UpdateContact();
            System.Console.WriteLine(new string('-', 100));
            break;
        default:
            System.Console.WriteLine("Er : This simvol is not correct");
            break;

    }
}


void AddContact()
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
        contactService.Add(contact);
    }
    else
    {
        System.Console.WriteLine("Doesn't coreect simvol");
    }
}
void GetAll()
{
    Console.Clear();
    List<Contact> contacts = contactService.GetAll();
    ConsoleList(contacts);
}
void Get()
{
    Console.Clear();
    System.Console.WriteLine("Kontaktı hansı parametrə görə axtarmaq istəyirsiz?\n Ad -> (a),\nSoyad -> (s),\nTelefon -> (t),\nEmail -> (e)");
    string answer = Console.ReadLine();
    switch (answer.ToLower())
    {
        case "a":
            System.Console.WriteLine("Ad daxil edin");
            string name = Console.ReadLine();
            ConsoleContact(contactService.GetBy(x => x.FirstName == name));
            break;
        case "s":
            System.Console.WriteLine("Soyad daxil edin");
            string lastName = Console.ReadLine();
            ConsoleContact(contactService.GetBy(x => x.LastName == lastName));
            break;
        case "t":
            System.Console.WriteLine("Telefon daxil edin");
            string phone = Console.ReadLine();
            ConsoleContact(contactService.GetBy(x => x.Phone == phone));
            break;
        case "e":
            System.Console.WriteLine("Email daxil edin");
            string email = Console.ReadLine();
            ConsoleContact(contactService.GetBy(x => x.Email == email));
            break;
        default:
            System.Console.WriteLine("Yalnis simvol");
            break;
    }
}
void Delete()
{

    System.Console.WriteLine("Silmək istədiyiniz Kontaktın İd sini daxil edin");
    int answer = int.Parse(Console.ReadLine());
    Contact deletedContact = contactService.GetBy(x => x.Id == answer);
    if (deletedContact == null) System.Console.WriteLine("Bu kontakt tapılmadı");
    else contactService.Delete(deletedContact);
}
void UpdateContact()
{
    Console.Clear();
    Contact contact = new Contact();
    Console.WriteLine("Ad daxil edin");
    contact.FirstName = Console.ReadLine();
    Console.WriteLine("Soyad daxil edin");
    contact.LastName = Console.ReadLine();
    Console.WriteLine("Telefon daxil edin");
    contact.Phone = Console.ReadLine();
    Console.WriteLine("Email daxil edin");
    contact.Email = Console.ReadLine();
    Console.WriteLine("Məlumatları yeniləmək istəyirsiz? Y/N");
    var answer = Console.ReadLine();
    if (answer.ToLower().Equals("y"))
    {
        contactService.Update(contact);
    }
    else
    {
        System.Console.WriteLine("Yenilənmədi");
    }
}
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