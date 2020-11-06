using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicCrm.DataAccessLayer.Abstract;
using BasicCrm.DataAccessLayer.Concrete.EfCore;
using BasicCrm.WebUI.Identity;
using BasicCrm.WebUI.Middlewares;
using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BasicCrm.WebUI
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationIdentityDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // password
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;

                options.Lockout.MaxFailedAccessAttempts = 15;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                options.Lockout.AllowedForNewUsers = true;

                /// ayný maille varsa oluþturmaz.
                options.User.RequireUniqueEmail = true;


                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });



            services.AddScoped<ICustomerDAL, EfCoreCustomerDal>();
            services.AddScoped<ICustomerService, CustomerManager>();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddRazorPages()
        .AddRazorRuntimeCompilation();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                TestingDatas.Datas();
            }
            app.UseStaticFiles();
            app.CustomStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                    );

                routes.MapRoute(
                     name: "DeleteCustomer",
                     template: "Customer/DeleteCustomer/{id?}",
                     defaults: new { controller = "Customer", action = "DeleteCustomer" }
                     );
                routes.MapRoute(
                    name: "UpdateCustomer",
                    template: "Customer/UpdateCustomer/{id?}",
                    defaults: new { controller = "Customer", action = "UpdateCustomer" }
                    );

            });
        }
    }
}
