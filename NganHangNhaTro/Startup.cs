using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NganHangNhaTro.Data;
using NganHangNhaTro.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Westwind.AspNetCore.LiveReload;

namespace NganHangNhaTro
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
            services.AddControllersWithViews()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            services.AddRazorPages();

            services.AddDbContext<MyDbContext>
                (opts => opts.UseSqlServer(Configuration["ConnectionString:ConnectStr"]));

            // Add framework services.
            services.AddMvc();

            services.AddScoped<ILevelService, LevelService>();
            services.AddScoped<IAgentService, AgentService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IRealEstateService, RealEstateService>();
            services.AddScoped<IRealEstateTypeService, RealEstateTypeService>();
            

            services.AddLiveReload();
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddMvc().AddRazorRuntimeCompilation();

            //authentication cookie
            services.AddAuthentication("MyCookieScheme")
               .AddCookie("MyCookieScheme", options =>
               {
                   options.AccessDeniedPath = new PathString("/AdminArea/Account/Denied");
                   options.Cookie = new CookieBuilder
                   {
                       HttpOnly = true,
                       Name = "HakunaMata.Cookie",
                       SameSite = SameSiteMode.Lax,
                       SecurePolicy = CookieSecurePolicy.SameAsRequest
                   };
                   options.LoginPath = new PathString("/AdminArea/Account/Login");
               });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseLiveReload();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                    );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=ClientRealEstate}/{action=Index}/{id?}");
            });
        }
    }
}
