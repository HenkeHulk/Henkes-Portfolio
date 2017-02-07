using Portfolio.DataAccessLayer.DomainClasses;
using Portfolio.Repository.Repositories;
using Portfolio.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.WebUI.Helpers
{
    public class ContactHelper
    {
        ContactRepository _cRepo = new ContactRepository();
        VendorHelper vendorHelper = new VendorHelper();
        public void InsertOrUpdate(ContactViewModel contactmodel)
        {
            var dbContact = new Contact()
            {
                VendorId = contactmodel.VendorId,
                FirstName = contactmodel.FirstName,
                SureName = contactmodel.SureName,
                EmailAddress = contactmodel.EmailAddress,
                PhoneNumber = contactmodel.PhoneNumber
            };
            _cRepo.InsertOrUpdate(dbContact);
        }


        public ContactViewModel FindContact(int id)
        {
            var dbContact = _cRepo.Find(id);
            var contact = new ContactViewModel()
            {
                Id = dbContact.Id,
                FirstName = dbContact.FirstName,
                SureName = dbContact.SureName,
                EmailAddress = dbContact.EmailAddress,
                PhoneNumber = dbContact.PhoneNumber,
                VendorId = dbContact.VendorId
            };
            return contact;
        }

        public ContactViewModel FindContactByVendorId(int id)
        {
            var vendor = vendorHelper.FindVendor(id);
            var c = FindContact(vendor.Contact.Id);
            
            var contact = new ContactViewModel()
            {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    SureName = c.SureName,
                    EmailAddress = c.EmailAddress,
                    PhoneNumber = c.PhoneNumber,
                    VendorId = c.VendorId
            };
            return contact;
        }

    }
}