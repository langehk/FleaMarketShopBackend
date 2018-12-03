using System;
using FleaMarketShop.Core.ApplicationService;
using FleaMarketShop.Core.ApplicationService.Implementations;
using FleaMarketShop.Core.DomainService;
using FleaMarketShop.Infrastructure.Data;
using FleaMarketShop.Infrastructure.Data.Repositories;
using FleaMarketShopRestApi.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace FleaMarketShopRestApi
{
    public class Startup
    {

        private IConfiguration _conf { get; }

        private IHostingEnvironment _env { get; set; }

        public Startup(IHostingEnvironment env)
        {
            _env = env;

            var builder = new ConfigurationBuilder()

                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
                _conf = builder.Build();
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Byte[] secretBytes = new byte[40];
            Random rand = new Random();
            rand.NextBytes(secretBytes);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    //ValidAudience = "TodoApiClient",
                    ValidateIssuer = false,
                    //ValidIssuer = "TodoApi",
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretBytes),
                    ValidateLifetime = true, //validate the expiration and not before values in the token
                    ClockSkew = TimeSpan.FromMinutes(5) //5 minute tolerance for the expiration date
                };
            });

            services.AddCors();

            // Allows all headers + methods 
            services.AddCors(options =>
            {
            options.AddPolicy("AllowAllOrigins",
                  builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();


            // Ensures that references wont loop. "Reference loop handling"
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });


            if (_env.IsDevelopment())
            {
                services.AddDbContext<FleaMarketShopContext>(
                    opt => opt.UseSqlite("Data source=FleaMarketShop.db"));
                
            }
            else 
            {
                services.AddDbContext<FleaMarketShopContext>(
                    opt => opt.UseSqlServer(_conf.GetConnectionString("defaultConnection")));
            }

            // Register database initializer
            services.AddTransient<IDbInitializer, DbInitializer>();

            // Register the AuthenticationHelper in the helpers folder for dependency
            // injection. It must be registered as a singleton service. The AuthenticationHelper
            // is instantiated with a parameter. The parameter is the previously created
            // "secretBytes" array, which is used to generate a key for signing JWT tokens,
            services.AddSingleton<IAuthenticationHelper>(new AuthenticationHelper(secretBytes));
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Initialize the database and the AuthenticationHelper.
            using (var scope = app.ApplicationServices.CreateScope())
            {
                // Initialize the database
                var services = scope.ServiceProvider;
                var dbContext = services.GetService<FleaMarketShopContext>();
                var dbInitializer = services.GetService<IDbInitializer>();
                dbInitializer.Initialize(dbContext);
            }

            // For convenience, I want detailed exception information always. However, this statement should
            // be removed, when the application is released.
            app.UseDeveloperExceptionPage();


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using(var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<FleaMarketShopContext>();                   
                }
            }
            else
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<FleaMarketShopContext>();
                    ctx.Database.EnsureCreated();
                }
                app.UseHsts();
            }

            app.UseCors("AllowAllOrigins");
           
            app.UseAuthentication();
            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
