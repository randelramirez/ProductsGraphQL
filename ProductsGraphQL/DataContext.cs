using Microsoft.EntityFrameworkCore;
using ProductsGraphQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsGraphQL
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }
    }
}
