using Portfolio.WebUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.WebUI.Controllers
{
    public class HomeController : Controller
    {
        ProductHelper prodHelper = new ProductHelper();
        public ActionResult Index()
        {
            var prodList = prodHelper.AllProducts().ToList();
            return View(prodList);
        }
        
    }
}