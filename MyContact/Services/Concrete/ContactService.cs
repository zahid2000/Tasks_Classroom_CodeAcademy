using MyContact.Models;
using MyContact.Services.Abstract;
using MyContact.DataAccess.Abstract;
using MyContact.Core.Constants;
using System.Linq.Expressions;

namespace MyContact.Services.Concrete
{
    public class ContactService : IContactService
    {
        private IContactRepository _contactRepository;
        private ILoggerService _loggerService;
        public ContactService(IContactRepository contactRepository,ILoggerService loggerService)
        {
            _contactRepository=contactRepository;
             _loggerService=loggerService;
        }
        public void Add(Contact contact)
        {
            _contactRepository.Add(contact);
            _loggerService.Log(Messages.Added);
        }

        public void Delete(Contact contact)
        {
           _contactRepository.Delete(contact);
            _loggerService.Log(Messages.Deleted);
        }

        public List<Contact> GetAll(Expression<Func<Contact,bool>> filter=null)
        {
            var result=_contactRepository.GetAll(filter);
            if (result==null)
            {
                _loggerService.Log(Messages.NotFound);  
                return result;             
            }
            _loggerService.Log(Messages.Listed);
            return result;
        }

        public Contact GetBy(Expression<Func<Contact,bool>> filter)
        {
            var result=_contactRepository.Get(filter);
            if (result==null)
            {
                _loggerService.Log(Messages.NotFound);  
                return result;             
            }           
            return result;
        }

        public void Update(Contact contact)
        {
            _contactRepository.Update(contact);
            _loggerService.Log(Messages.Updated);
        }
        
    }
}