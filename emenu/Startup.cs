using emenu.Core.Contracts;
using emenu.Core.Services;
using emenu.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace emenu
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void ConfigureServices(IServiceCollection services)
        {
           
                services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));

                services.AddControllers();

                services.AddAutoMapper(typeof(Startup));

              //  ConfigureIdentityAndAuthentication(services);

                ConfigureSwagger(services);

                RegisterServices(services);

                //cors configuration
                services.AddCors(o => o.AddPolicy("MyPolicyCross", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                }));
        }
           
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                                IWebHostEnvironment env,
                                ApplicationDbContext dbContext,
                                IUnitOfWork unitOfWork)
        {
            try
            {
                MySeedClass.Seed(dbContext, unitOfWork);

                if (env.IsDevelopment() || env.IsStaging())
                {
                    app.UseDeveloperExceptionPage();
                }

                // app.UseCors();
                app.UseCors("MyPolicyCross");

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Like Card API V1");
                });

                app.UseHttpsRedirection();

                app.UseAuthentication();

                app.UseRouting();

                app.UseAuthorization();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();//.RequireCors("MyPolicyCross");
                });


                //  config.EnableCors(new EnableCorsAttribute());

                app.UseStaticFiles();// For the wwwroot folder


                app.UseStaticFiles(new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(
                                Path.Combine(Directory.GetCurrentDirectory(), "images")),
                    RequestPath = "/images"
                });
                //Enable directory browsing
                app.UseDirectoryBrowser(new DirectoryBrowserOptions
                {
                    FileProvider = new PhysicalFileProvider(
                                Path.Combine(Directory.GetCurrentDirectory(), "images")),
                    RequestPath = "/images"
                });
            }
            catch (Exception e)
            {

            }
        }
        private void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Emenu API", Version = "V1" });
                c.CustomSchemaIds(x => x.FullName);
            });
        }


        private void RegisterServices(IServiceCollection services)
        {

            services.AddScoped<HelperService>();
            services.AddScoped<ProductService>();
            services.AddScoped<ProductVariantService>();
            services.AddScoped<VariantService>();
            services.AddScoped<VariantValueService>();


            //persistance
            services.AddScoped<IUnitOfWork, UnitOfWork>();
         
            services.AddScoped<IProductRepository, ProductRepository>();
           
            services.AddScoped<IImageRepository, ImagesRepository>();

            services.AddScoped<IProductVariantRepository, ProductVariantRepository>();
            services.AddScoped<IVariantRepository, VariantRepository>();
            services.AddScoped<IVariantValueRepository, VariantValueRepository>();


        }

        // This method gets called by the runtime. Use this method to add services to the container.
       
    }
}
