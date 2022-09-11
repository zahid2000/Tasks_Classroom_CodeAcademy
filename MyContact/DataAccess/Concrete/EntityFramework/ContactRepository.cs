using MyContact.Core.DataAccess.Concrete.EntityFramework;
using MyContact.DataAccess.Abstract;
using MyContact.Models;

namespace MyContact.DataAccess.Concrete.EntityFramework
{
    public class ContactRepository : EFRepositoryBase<Contact, EFContactContext>, IContactRepository
    {

    }
}