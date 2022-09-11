using MyContact.Models;
using MyContact.Services.Abstract;
using MyContact.DataAccess.Abstract;
using MyContact.Core.Constants;
using System.Linq.Expressions;
using MyContact.Core.Utilities.Validation;

namespace MyContact.Services.Concrete.EntityFramework
{
    public class EfContactService : IContactService
    {
        private IContactRepository _contactRepository;
        private ILoggerService _loggerService;
        public EfContactService(IContactRepository contactRepository, ILoggerService loggerService)
        {
            _contactRepository = contactRepository;
            _loggerService = loggerService;
        }
        public void Add(Contact contact)
        {
            if (!Regexs.IsEmail(contact.Email))
            {
                _loggerService.Log(Messages.NotValidEmail, ConsoleColor.Red);
            }
            if (!Regexs.IsPhone(contact.Phone))
            {
                _loggerService.Log(Messages.NotValidPhone, ConsoleColor.Red);
            }
            else
            {
                _contactRepository.Add(contact);
                _loggerService.Log(Messages.Added, ConsoleColor.Green);
            }
        }

        public void Delete(Contact contact)
        {
            _contactRepository.Delete(contact);
            _loggerService.Log(Messages.Deleted, ConsoleColor.Green);
        }

        public Contact Get(Contact contact)
        {
            var result = _contactRepository.Get(contact);
            if (result == null)
            {
                _loggerService.Log(Messages.NotFound, ConsoleColor.Red);
                return result;
            }
            return result;
        }

        public List<Contact> GetAll(Expression<Func<Contact, bool>> filter = null)
        {
            var result = _contactRepository.GetAll(filter);
            if (result == null)
            {
                _loggerService.Log(Messages.NotFound, ConsoleColor.Red);
                return result;
            }
            _loggerService.Log(Messages.Listed, ConsoleColor.Green);
            return result;
        }

        public Task<List<Contact>> GetAllAsync(Expression<Func<Contact, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Contact GetBy(Expression<Func<Contact, bool>> filter)
        {
            var result = _contactRepository.Get(filter);
            if (result == null)
            {
                _loggerService.Log(Messages.NotFound, ConsoleColor.Red);
                return result;
            }
            return result;
        }

        public void Update(Contact contact)
        {
            if (!Regexs.IsEmail(contact.Email))
            {
                _loggerService.Log(Messages.NotValidEmail, ConsoleColor.Red);
            }
            if (!Regexs.IsPhone(contact.Phone))
            {
                _loggerService.Log(Messages.NotValidPhone, ConsoleColor.Red);
            }
            else
            {

                _contactRepository.Update(contact);
                _loggerService.Log(Messages.Updated, ConsoleColor.Green);
            }
        }

    }
}