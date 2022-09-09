using MyContact.DataAccess.Abstract;
using MyContact.DataAccess.Concrete;
using MyContact.Models;
using MyContact.Services.Abstract;
using MyContact.Services.Concrete;

ILoggerService loggerService=new LoggerService();
IContactRepository contactRepository= new ContactRepository();
IContactService contactService= new ContactService(contactRepository,loggerService);

while (true)
{
    Console.WriteLine(
        "Kontakt əlavə et-> (a)\n"+
        "Kontaktları listələ -> (l)"+
        "Kontak axtar -> (s)"
    );  System.Console.WriteLine( new string('-',100));
    string answer=Console.ReadLine();
      System.Console.WriteLine( new string('-',100));
    switch (answer.ToLower())
    {
        case  "a":
            AddContact();
            System.Console.WriteLine( new string('-',100));
            break;
        case  "l":
            GetAll();
             System.Console.WriteLine( new string('-',100));
            break;
        case  "s":
            Get();
            System.Console.WriteLine( new string('-',100));
        break;

    }
}


void AddContact(){
    Contact contact=new Contact();
    Console.WriteLine("Ad daxil edin");
    contact.FirstName=Console.ReadLine();
     Console.WriteLine("Soyad daxil edin");
    contact.LastName=Console.ReadLine();
     Console.WriteLine("Telefon daxil edin");
    contact.Phone=Console.ReadLine();
     Console.WriteLine("Email daxil edin");
    contact.Email=Console.ReadLine();
    Console.WriteLine("Daxil etmək istəyirsiz? Y/N");
    var answer=Console.ReadLine();
    if(answer.ToLower().Equals("y")){
        contactService.Add(contact);
    }
    else{
        System.Console.WriteLine("Daxil edilmədi");
    }
}
void GetAll(){
    List<Contact> contacts=contactService.GetAll();
    foreach (Contact contact in contacts)
    {
        System.Console.WriteLine($"{contact.FirstName} {contact.LastName} {contact.Phone} {contact.Email}");
    }
}
void Get(){
    System.Console.WriteLine("Kontaktı hansı parametrə görə axtarmaq istəyirsiz?\n Ad -> (a),\nSoyad -> (s),\nTelefon -> (t),\nEmail -> (e)");
    string answer=Console.ReadLine();
    switch (answer.ToLower())
    {
        case "a":
         ConsoleContact(contactService.GetBy(x=>x.FirstName==answer));
        break;
        case "s":
         ConsoleContact(contactService.GetBy(x=>x.LastName==answer));
         break;
        
        case "t":
         ConsoleContact(contactService.GetBy(x=>x.Phone==answer));
        break;
         case "e":
         ConsoleContact(contactService.GetBy(x=>x.Email==answer));
        break;
        default:
            System.Console.WriteLine("Belə məlumat yoxdur");
        break;
    }
}
void Delete(){
    System.Console.WriteLine("Silmək istədiyiniz Kontaktın İd sini daxil edin");
    int answer=int.Parse(Console.ReadLine());
    Contact deletedContact=contactService.GetBy(x=>x.Id==answer);
    if(deletedContact==null)System.Console.WriteLine("Bu kontakt tapılmadı");
    else contactService.Delete(deletedContact);
}
void ConsoleList(List<Contact> contacts){
    System.Console.WriteLine("{0,-15}{1,-25}{2-20}{3,-20}{4,-35}","Id","FirstName","LastName","Phone","Email");
     foreach (Contact contact in contacts)
    {
        System.Console.WriteLine("{0,-15}{1,-25}{2-20}{3,-20}{4,-35}",contact.Id,contact.FirstName, contact.LastName,contact.Phone,contact.Email);
    }
}
void ConsoleContact(Contact contact){
      System.Console.WriteLine("{0,-15}{1,-25}{2-20}{3,-20}{4,-35}","Id","FirstName","LastName","Phone","Email");
     System.Console.WriteLine("{0,-15}{1,-25}{2-20}{3,-20}{4,-35}",contact.Id,contact.FirstName, contact.LastName,contact.Phone,contact.Email);
    
}