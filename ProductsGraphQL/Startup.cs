using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.GraphiQL;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductsGraphQL.GraphQL;


namespace ProductsGraphQL
{
    public class Startup
    {

        // to access on ConfigureServices and then inject it on the controller
        private readonly IWebHostEnvironment environment;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            this.environment = environment;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(); //not really needed
            services.AddDbContext<DataContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("ProductsGraphQL")));
            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<ProductService>();

            services.AddScoped<ProductsGraphQLSchema>();

            services.AddGraphQL(o =>
            {
                o.EnableMetrics = true;
                o.ExposeExceptions = environment.IsDevelopment();
            })
            .AddGraphTypes(ServiceLifetime.Scoped);

            //needed for .NET CORE 3.X
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            DataContext dataContext /*we added the DataContext here to seed the database and development purposes*/)
        {
            app.UseGraphQL<ProductsGraphQLSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
            app.UseGraphiQLServer(new GraphiQLOptions()); // graphiql

            var dataInitializer = new DataInitializer(dataContext);
            if (!dataContext.Suppliers.Any())
            {
                dataInitializer.CreateSuppliers();
            }
            if (!dataContext.Products.Any())
            {
                dataInitializer.CreateProducts();
            }


        }
    }
}
