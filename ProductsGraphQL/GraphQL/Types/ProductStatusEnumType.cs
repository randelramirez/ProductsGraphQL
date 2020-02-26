using GraphQL.Types;
using ProductsGraphQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsGraphQL.GraphQL.Types
{
    public class ProductStatusEnumType : EnumerationGraphType<ProductStatus>
    {
        public ProductStatusEnumType()
        {
            Name = nameof(Models.Product.Status);
            Description = "The status of the product";
        }
    }
}
