using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ollok.Extensions;
using Ollok.Models;

namespace Ollok
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            string conString = Configuration["Data:ConnectionString"];

            services.AddDbContext<ApplicationDbContext>(opt => {
                opt.UseSqlServer(conString);
            });

            services.AddDbEntities();

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                    options.Cookie.Name = "Ollok-Admin";
                });

            services.AddAntiforgery(opt => opt.Cookie.Name = "OllokAntiforgery");

            services.AddMvc(opt => opt.EnableEndpointRouting = false);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMvc(routing => {
                routing.MapAreaRoute(
                    name: "Admin",
                    areaName: "Admin",
                    template: "admin/{controller=Product}/{action=Product}"
                    );
                routing.MapRoute(
                    name: null,
                    template: "{category}/{productName}-{productId}",
                    defaults: new { controller = "Product", action = "Product" }
                    );
                routing.MapRoute(
                    name: null,
                    template: "{categoryName}/Page-{productPage:int}",
                    defaults: new { controller="Product", action="List"}
                    );
                routing.MapRoute(
                    name: null,
                    template: "Page-{productPage:int}",
                    defaults: new { controller = "Product", action = "List"}
                    );
                routing.MapRoute(
                    name: null,
                    template: "{categoryName}",
                    defaults: new { controller = "Product", action = "List"}
                    );
                routing.MapRoute(
                        name: "default",
                        template: "{controller=Product}/{action=List}/{id?}"
                    );
            });
            
        }
    }
}
