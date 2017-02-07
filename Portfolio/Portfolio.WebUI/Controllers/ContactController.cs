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
    }
}