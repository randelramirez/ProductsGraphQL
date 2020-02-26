using GraphQL.Types;
using ProductsGraphQL.GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsGraphQL.GraphQL
{
    // ProductsGraphQL = name of the project, not necessarily a convention of GraphQL
    public class ProductsGraphQLQuery : ObjectGraphType
    {

        public ProductsGraphQLQuery(ProductService productService)
        {
            Field<ListGraphType<ProductType>>(
                "products",
                resolve: context => productService.GetAll().Result
            );
        }
    }
}
