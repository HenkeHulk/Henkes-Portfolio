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
        public List<ProductViewModel> AllProductsByCatalogId(int catalogId)
        {
            var dbAllProductsByCatalogId = _prodRepo.All.Where(x => x.CatalogId == catalogId);
            var AllProducts = new List<ProductViewModel>();

            foreach (var dbProd in dbAllProductsByCatalogId)
            {

                var Product = new ProductViewModel()
                {
                    Id = dbProd.Id,
                    CatalogId = dbProd.CatalogId,
                    DepartmentId = dbProd.DepartmentId,
                    VendorId = dbProd.VendorId,
                    Title = dbProd.Title,
                    Price = dbProd.Price,
                    ItemsInStock = dbProd.ItemsInStock,
                    Department = new DepartmentViewModel() { Id = dbProd.Department.Id, Name = dbProd.Department.Name },
                    Vendor = new VendorViewModel() { Id = dbProd.Vendor.Id, Name = dbProd.Vendor.Name, City = dbProd.Vendor.City, Country = dbProd.Vendor.Country, PostalCode = dbProd.Vendor.PostalCode, Street = dbProd.Vendor.Street }
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
                    CatalogId = dbProd.CatalogId,
                    DepartmentId = dbProd.DepartmentId,
                    VendorId = dbProd.VendorId,
                    Title = dbProd.Title,
                    Price = dbProd.Price,
                    ItemsInStock = dbProd.ItemsInStock
                    //Department = new DepartmentViewModel() { Id = dbProd.Department.Id, Name = dbProd.Department.Name },
                    //Vendor = new VendorViewModel() { Id = dbProd.Vendor.Id, Name = dbProd.Vendor.Name, City = dbProd.Vendor.City, Country = dbProd.Vendor.Country, PostalCode = dbProd.Vendor.PostalCode, Street = dbProd.Vendor.Street }
                };
                AllProducts.Add(Product);
            }
            return AllProducts.ToList();
        }
    }
}