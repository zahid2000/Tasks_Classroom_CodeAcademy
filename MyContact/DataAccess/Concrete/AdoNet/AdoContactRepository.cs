using MyContact.Core.DataAccess.Abstract;
using MyContact.Core.DataAccess.Concrete.Ado.Net;
using MyContact.DataAccess.Abstract;
using MyContact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContact.DataAccess.Concrete.AdoNet
{
    public class AdoContactRepository:AdoRepositoryBase<Contact>,IContactRepository
    {
    }
}
