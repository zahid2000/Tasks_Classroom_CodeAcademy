using Day23_Lesson_Part2.Models;

namespace Day23_Lesson_Part2.Services
{
    public class ContactService
    {
        List<Contact> _db = new List<Contact>
        {
            new Contact{Id=1,Firstname="Zahid",LastName="Mamedov",Phone="0705696373"},
            new Contact{Id=2,Firstname="Esger",LastName="Babayev",Phone="05068686905"},
            new Contact{Id=3,Firstname="Tahir",LastName="Kerimov",Phone="04040444044"},
            new Contact{Id=4,Firstname="Resul",LastName="Eliyev", Phone="0705696373"},
            new Contact{Id=5,Firstname="Ehed",LastName="Nadirov", Phone="0705696373"},
            new Contact{Id=6,Firstname="Ramiz",LastName="Kerimov",Phone="0705696373"},
            new Contact{Id=7,Firstname="Cahid",LastName="Mamedov",Phone="0705696373"},
            new Contact{Id=8,Firstname="Nail",LastName="Yusiufov",Phone="0705696373"},
        };

        public List<Contact> GetAll()
        {
            return _db;
        }
        public List<Contact> GetAllCount(int count)
        {
            return _db.Take(count).ToList();
        }
        public void Add(Contact contact)
        {
            _db.Add(contact);
        }

    }
}
