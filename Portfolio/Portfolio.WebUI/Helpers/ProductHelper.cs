﻿using Portfolio.DataAccessLayer.DomainClasses;
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
                CatalogId = product.CatalogId,
                DepartmentId = product.DepartmentId,
                ItemsInStock = product.ItemsInStock,
                Title = product.Title,
                Price = product.Price,
                VendorId = product.VendorId
            };
            _prodRepo.InsertOrUpdate(dbProduct);
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
                    CatalogId = dbProd.CatalogId,
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
                    Title = dbProd.Title,
                    Price = dbProd.Price,
                    ItemsInStock = dbProd.ItemsInStock
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
                };
                AllProducts.Add(Product);
            }
            return AllProducts.ToList();
        }
    }
}