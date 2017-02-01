using Portfolio.Repository.Repositories;
using Portfolio.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.WebUI.Helpers
{
    public class VendorHelper
    {
        VendorRepository _vRepo = new VendorRepository();
        ProductHelper pHelper = new ProductHelper();

        public VendorViewModel FindVendor(int id)
        {
            var dbVendor = _vRepo.Find(id);
            var vendor = new VendorViewModel()
            {
                Id = dbVendor.Id,
                Name = dbVendor.Name,
                City = dbVendor.City,
                Country = dbVendor.Country,
                PostalCode = dbVendor.PostalCode,
                Street = dbVendor.Street
            };
            return vendor;
        }

        public List<VendorViewModel> AllVendors()
        {
            var dbVendors = _vRepo.All.ToList();
            var vendors = new List<VendorViewModel>();

            foreach (var _vendor in dbVendors)
            {
                var productsByVendorId = new List<ProductViewModel>();
                productsByVendorId = pHelper.AllProductsByVendorId(_vendor.Id);
                var vendor = new VendorViewModel()
                {
                    Id = _vendor.Id,
                    Street = _vendor.Street,
                    City = _vendor.City,
                    Country = _vendor.Country,
                    Name = _vendor.Name,
                    PostalCode = _vendor.PostalCode,
                    Products = productsByVendorId
                };
                vendors.Add(vendor);
            }
            return vendors;
        }
    }
}