using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsGraphQL.GraphQL
{
    // ProductsGraphQLSchema = name of the project not necessarily because of GraphQL convention
    public class ProductsGraphQLSchema : Schema
    {
        public ProductsGraphQLSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<ProductsGraphQLQuery>();
        }
    }
}
