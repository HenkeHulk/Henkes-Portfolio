using Portfolio.WebUI.Helpers;
using Portfolio.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.WebUI.Controllers
{
    public class ContactController : Controller
    {
        ContactHelper cHelper = new ContactHelper();
        [HttpGet]
        public ActionResult AddContact(int Id)
        {
            var contact = new ContactViewModel()
            {
                VendorId = Id
            };
            return View(contact);
        }

        [HttpPost]
        public ActionResult AddContact(ContactViewModel modelContact)
        {
            var contact = new ContactViewModel()
            {
                VendorId = modelContact.VendorId,
                FirstName = modelContact.FirstName,
                SureName = modelContact.SureName,
                EmailAddress = modelContact.EmailAddress,
                PhoneNumber = modelContact.PhoneNumber
            };
            cHelper.InsertOrUpdate(contact);
            return Redirect("~/Vendor/Details/" + contact.VendorId);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var contact = cHelper.FindContact(id);
            var contactModel = new ContactViewModel()
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                SureName = contact.SureName,
                EmailAddress = contact.EmailAddress,
                PhoneNumber = contact.PhoneNumber,
                VendorId = contact.VendorId
            };
            return View(contactModel);
        }

        [HttpPost]
        public ActionResult Details(ContactViewModel contact)
        {
            var updateContact = new ContactViewModel()
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                SureName = contact.SureName,
                EmailAddress = contact.EmailAddress,
                PhoneNumber = contact.PhoneNumber,
                VendorId = contact.VendorId
            };
            cHelper.InsertOrUpdate(updateContact);

            return Redirect("~/Vendor/Details/" + contact.VendorId);
        }

        public ActionResult DeleteContact(int id)
        {
            var delContact = cHelper.FindContact(id);
            cHelper.DeleteContact(delContact.Id);
            return Redirect("~/Vendor/Details/" + delContact.VendorId);
        }
    }
}