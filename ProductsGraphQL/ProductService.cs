using Microsoft.EntityFrameworkCore;
using ProductsGraphQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsGraphQL
{
    public class ProductService
    {
        private readonly DataContext context;

        public ProductService(DataContext context)
        {
            this.context = context;
        }

        public async Task<List<Product>> GetAll()
        {
            return await this.context.Products.ToListAsync();
        }
    }
}
