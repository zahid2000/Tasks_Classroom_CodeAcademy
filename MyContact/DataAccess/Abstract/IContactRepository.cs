using MyContact.Core.DataAccess.Abstract;
using MyContact.Core.DataAccess.Concrete;
using MyContact.DataAccess.Concrete;
using MyContact.Models;

namespace MyContact.DataAccess.Abstract
{
    public interface IContactRepository:IRepository<Contact>
    {
        
    }
}