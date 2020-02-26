using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsGraphQL.GraphQL.Types
{
    public class ProductStatusEnumType : EnumerationGraphType<ProductType>
    {
        public ProductStatusEnumType()
        {
            Name = nameof(Models.Product.Status);
            Description = "The status of the product";
        }
    }
}
