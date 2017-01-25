using Portfolio.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portfolio.DataAccessLayer.DomainClasses;
using Portfolio.DataAccessLayer;

namespace Portfolio.Repository.Repositories
{
    public class ContactRepository : IContact
    {
        CatalogDbContext dbContext = new CatalogDbContext();
        public IQueryable<Contact> All
        {
            get
            {
                return dbContext.Contacts;
            }
        }

        public void Delete(Contact entity)
        {
            var delContact = Find(entity.Id);
            dbContext.Contacts.Remove(delContact);
            Save();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public Contact Find(int id)
        {
            return dbContext.Contacts.Find(id);
        }

        public void InsertOrUpdate(Contact entity)
        {
            var existingContact = All.Where(x => x.Id == entity.Id).FirstOrDefault();
            if (existingContact == null)
            {
                dbContext.Contacts.Add(entity);
            }
            else
            {
                existingContact.Id = entity.Id;
                existingContact.FirstName = entity.FirstName;
                existingContact.SureName = entity.SureName;
                existingContact.EmailAddress = entity.EmailAddress;
                existingContact.VendorId = entity.VendorId;
            }
            Save();
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}
