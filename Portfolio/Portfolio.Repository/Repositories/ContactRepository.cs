using Portfolio.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portfolio.DataAccessLayer.DomainClasses;

namespace Portfolio.Repository.Repositories
{
    public class ContactRepository : IContact
    {
        public IQueryable<Contact> All
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Delete(Contact entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Contact Find(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertOrUpdate(Contact entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
