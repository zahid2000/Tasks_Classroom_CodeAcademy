using MyContact.Core.Constants;
using MyContact.Core.Utilities.Validation;
using MyContact.DataAccess.Abstract;
using MyContact.Models;
using MyContact.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyContact.Services.Concrete.Ado.Net
{
    public class AdoContactService : IContactService
    {
        private IContactRepository _contactRepository;
        private ILoggerService _loggerService;

        public AdoContactService(IContactRepository contactRepository, ILoggerService loggerService)
        {
            _contactRepository = contactRepository;
            _loggerService = loggerService;
        }

        public void Add(Contact contact)
        {
            if (!Regexs.IsEmail(contact.Email))
            {
                _loggerService.Log(Messages.NotValidEmail,ConsoleColor.Red);
            }
            if (!Regexs.IsPhone(contact.Phone))
            {
                _loggerService.Log(Messages.NotValidPhone,ConsoleColor.Red);
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

        public async Task<List<Contact>> GetAllAsync(Expression<Func<Contact, bool>> filter = null)
        {
            var result= await _contactRepository.GetAllAsync(filter);
            
            if (result == null)
            {
                _loggerService.Log(Messages.NotFound, ConsoleColor.Red);
                return result;
            }
            _loggerService.Log(Messages.Listed, ConsoleColor.Green);
            return result;
        }

        public Contact GetBy(Expression<Func<Contact, bool>> filter)
        {
            throw new NotImplementedException();
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
