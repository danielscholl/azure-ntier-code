using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SimpleApp.API.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace SimpleApp.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = @"Data Source=(localdb)\MSSQLLocalDB;Database=SimpleAppDB;Trusted_connection=True;";
            //var connection = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=SimpleAppDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            services.AddScoped<ProductsRepository>();
            services.AddScoped<PetsRepository>();

            //services.AddDbContext<SimpleAppContext>(opt => opt.UseInMemoryDatabase("simpleApp"));
            services.AddDbContext<SimpleAppContext>(opt => opt.UseSqlServer(connection));

            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "SimpleApp.API",
                    Version = "v1"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SimpleApp v1");
                c.RoutePrefix = string.Empty;
            });
            app.UseMvc();
        }
    }
}
