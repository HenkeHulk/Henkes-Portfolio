using Portfolio.WebUI.Helpers;
using Portfolio.WebUI.Models;
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
            var product = new ProductViewModel()
            {
                Id = 2,
                CatalogId = 1,
                VendorId = 1,
                DepartmentId = 1,
                Title = "FIFA 17",
                ItemsInStock = 5,
                Price = 5
            };
            prodHelper.InsertOrUpdate(product);
            return View();
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(ProductViewModel product)
        {
            var modelProduct = new ProductViewModel()
            {
                Id = product.Id,
                Title = product.Title,
                Price = product.Price,
                ItemsInStock = product.ItemsInStock
            };
            prodHelper.InsertOrUpdate(modelProduct);
            return RedirectToAction("Index");
        }

    }
}