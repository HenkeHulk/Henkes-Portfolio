using Portfolio.DataAccessLayer.DomainClasses;
using Portfolio.Repository.Repositories;
using Portfolio.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.WebUI.Helpers
{
    public class ProductHelper
    {
        ProductRepository _prodRepo = new ProductRepository();

        public void InsertOrUpdate(ProductViewModel product)
        {
            var dbProduct = new Product()
            {
                Id = product.Id,
                DepartmentId = product.DepartmentId,
                ItemsInStock = product.ItemsInStock,
                Title = product.Title,
                Price = product.Price,
                VendorId = product.VendorId
            };
            _prodRepo.InsertOrUpdate(dbProduct);
        }

        public ProductViewModel FindProductById(int id)
        {
            var dbProd = _prodRepo.Find(id);
            var product = new ProductViewModel()
            {
                Id = dbProd.Id,
                DepartmentId = dbProd.DepartmentId,
                VendorId = dbProd.VendorId,
                ItemsInStock = dbProd.ItemsInStock,
                Price = dbProd.Price,
                Title = dbProd.Title
            };
            return product;
        }

        public List<ProductViewModel> AllProductsByVendorId(int vendorId)
        {
            var dbAllProductsByCatalogId = _prodRepo.All.Where(x => x.VendorId == vendorId);
            var AllProducts = new List<ProductViewModel>();

            foreach (var dbProd in dbAllProductsByCatalogId)
            {

                var Product = new ProductViewModel()
                {
                    Id = dbProd.Id,
                    Title = dbProd.Title,
                    Price = dbProd.Price,
                    ItemsInStock = dbProd.ItemsInStock,
                    VendorId = dbProd.VendorId,
                    DepartmentId = dbProd.DepartmentId
                };
                AllProducts.Add(Product);
            }
            return AllProducts.ToList();
        }

        public List<ProductViewModel> AllProducts()
        {
            var dbAllProducts = _prodRepo.All;
            var AllProducts = new List<ProductViewModel>();

            foreach (var dbProd in dbAllProducts)
            {

                var Product = new ProductViewModel()
                {
                    Id = dbProd.Id,
                    DepartmentId = dbProd.DepartmentId,
                    VendorId = dbProd.VendorId,
                    Title = dbProd.Title,
                    Price = dbProd.Price,
                    ItemsInStock = dbProd.ItemsInStock
                };
                AllProducts.Add(Product);
            }
            return AllProducts.ToList();
        }
    }
}