using OscarWilde.Models;

namespace OscarWilde.ViewModels
{
    public class PhoneAndCompViewModel
    {
        public IEnumerable<Phone> Phones { get; set; }
        public IEnumerable<Computer> Computers { get; set; }
    }
}
