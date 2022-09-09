using System.Linq.Expressions;
using MyContact.Models;

namespace MyContact.Services.Abstract;

public interface IContactService
{
    void Add(Contact contact);
    void Delete(Contact contact);
    void Update(Contact contact);
    List<Contact>  GetAll(Expression<Func<Contact,bool>> filter=null);
    Contact GetBy(Expression<Func<Contact,bool>> filter);
}
