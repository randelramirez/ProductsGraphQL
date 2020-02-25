using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsGraphQL.Models
{
    public class Product
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int SupplierId { get; set; }

        public ProductStatus Status { get; set; }

        public Supplier Supplier { get; set; }
    }
}
