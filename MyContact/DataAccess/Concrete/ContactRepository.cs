using MyContact.Core.DataAccess.Concrete.EntityFramework;
using MyContact.DataAccess.Abstract;
using MyContact.Models;

namespace MyContact.DataAccess.Concrete
{
    public class ContactRepository:EFRepositoryBase<Contact,EFContactContext>,IContactRepository
    {
    
    }
}