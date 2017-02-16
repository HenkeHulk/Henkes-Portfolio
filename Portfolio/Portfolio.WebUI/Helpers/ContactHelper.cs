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
            var vendor = vendorHelper.FindVendor(contactmodel.VendorId);

            var dbContact = new Contact()
            {
                Id = contactmodel.Id,
                VendorId = contactmodel.VendorId,
                FirstName = contactmodel.FirstName,
                SureName = contactmodel.SureName,
                EmailAddress = contactmodel.EmailAddress,
                PhoneNumber = contactmodel.PhoneNumber
            };
            
            _cRepo.InsertOrUpdate(dbContact);
            var addVendor = new VendorViewModel()
            {
                Id = vendor.Id,
                Name = vendor.Name,
                Contact = vendor.Contact,
                ContactId = dbContact.Id,
                Street = vendor.Street,
                City = vendor.City,
                Country = vendor.Country,
                PostalCode = vendor.PostalCode,
                Products = vendor.Products
            };
            vendorHelper.InsertOrUpdate(addVendor);
        }

        public void DeleteContact(int id)
        {
            var delContact = _cRepo.Find(id);
            var vendor = vendorHelper.FindVendor(delContact.VendorId);
            var modelVendor = new VendorViewModel()
            {
                Id = vendor.Id,
                City = vendor.City,
                Contact = null,
                ContactId = 0,
                Country = vendor.Country,
                Name = vendor.Name,
                PostalCode = vendor.PostalCode,
                Products = vendor.Products,
                Street = vendor.Street
            };
            vendorHelper.InsertOrUpdate(modelVendor);
            _cRepo.Delete(delContact);
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
            var c = _cRepo.Find(vendor.ContactId);
            
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