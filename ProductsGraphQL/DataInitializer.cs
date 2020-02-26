﻿using Microsoft.EntityFrameworkCore;
using ProductsGraphQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsGraphQL
{
    public class DataInitializer
    {
        private readonly DataContext context;

        public DataInitializer(DataContext context)
        {
            this.context = context;
        }

        public void CreateSuppliers()
        {
            var suppliers = new List<Supplier>();
            suppliers.Add(new Supplier { Name = "HP", Address = "Mckinley" });
            suppliers.Add(new Supplier { Name = "Apple", Address = "Cupertino" });
            suppliers.Add(new Supplier { Name = "Microsoft", Address = "Seattle" });

            suppliers.ForEach(s => context.Add(s));
            this.context.SaveChanges();
        }

        public void CreateProducts()
        {
            var products = new List<Product>();

            //HP Products
            var hp = this.context.Suppliers.AsNoTracking().Single(s => s.Name == "HP");
            products.Add(new Product { Name = "Printer xxx-2020", Price = 300.50, Status = ProductStatus.Active, SupplierId = hp.Id });
            products.Add(new Product { Name = "Compaq Presario", Price = 500.80, Status = ProductStatus.Inactive, SupplierId = hp.Id });
            products.Add(new Product { Name = "HP-ENVY 15", Price = 800, Status = ProductStatus.Active, SupplierId = hp.Id });
            products.Add(new Product { Name = "HP-ENVY 17", Price = 1200.70, Status = ProductStatus.Active, SupplierId = hp.Id });
            products.Add(new Product { Name = "HP-PAVILION 14", Price = 550, Status = ProductStatus.Active, SupplierId = hp.Id });


            //APPLE Products
            var apple = this.context.Suppliers.AsNoTracking().Single(s => s.Name == "Apple");
            products.Add(new Product { Name = "iPhone 8", Price = 800, Status = ProductStatus.Active, SupplierId = apple.Id });
            products.Add(new Product { Name = "iPhone X", Price = 900, Status = ProductStatus.Inactive, SupplierId = apple.Id });
            products.Add(new Product { Name = "iPhone 11 Pro", Price = 1100, Status = ProductStatus.Active, SupplierId = apple.Id });
            products.Add(new Product { Name = "iPhone 11 Max", Price = 1200.70, Status = ProductStatus.Active, SupplierId = apple.Id });
            products.Add(new Product { Name = "iPad Pro", Price = 900, Status = ProductStatus.Active, SupplierId = apple.Id });
            products.Add(new Product { Name = "iPod", Price = 300, Status = ProductStatus.Inactive, SupplierId = apple.Id });

            //Microsoft
            var microsoft = this.context.Suppliers.AsNoTracking().Single(s => s.Name == "Microsoft");
            products.Add(new Product { Name = "Surface Pro 3", Price = 800, Status = ProductStatus.Active, SupplierId = microsoft.Id });
            products.Add(new Product { Name = "Surface Duo", Price = 1200, Status = ProductStatus.Inactive, SupplierId = microsoft.Id });
            products.Add(new Product { Name = "Surface Neo", Price = 1300, Status = ProductStatus.Active, SupplierId = microsoft.Id });
            products.Add(new Product { Name = "Zune", Price = 400.50, Status = ProductStatus.Discontinued, SupplierId = microsoft.Id });
            products.Add(new Product { Name = "Office 365", Price = 745.75, Status = ProductStatus.Active, SupplierId = microsoft.Id });
            products.Add(new Product { Name = "Visual Studio Enterprise", Price = 1100.85, Status = ProductStatus.Inactive, SupplierId = microsoft.Id });

            products.ForEach(p => context.Add(p));
            this.context.SaveChanges();
        }
    }
}
