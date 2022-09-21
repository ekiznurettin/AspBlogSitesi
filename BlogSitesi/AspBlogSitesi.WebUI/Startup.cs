using AspBlogSitesi.Businnes.AutoMapper.Profiles;
using AspBlogSitesi.Businnes.Extensions;
using AspBlogSitesi.WebUI.AutoMapper.Profiles;
using AspBlogSitesi.WebUI.Helpers.Abstract;
using AspBlogSitesi.WebUI.Helpers.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Text.Json.Serialization;

namespace AspBlogSitesi.WebUI
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            }).AddNToastNotifyToastr();
            services.AddSession();
            services.AddAutoMapper(typeof(ArticleProfile), typeof(CategoryProfile), typeof(UserProfile), typeof(ViewModelsProfile));
            services.LoadMyServices(connectionString:Configuration.GetConnectionString("LocalDB"));
            services.AddScoped<IImageHelper, ImageHelper>();
            services.ConfigureApplicationCookie(options => {
                options.LoginPath = new PathString("/Admin/User/Login");
                options.LogoutPath = new PathString("/Admin/User/Logout");
                options.Cookie = new CookieBuilder
                {
                    Name = "ProgrammersBlog",
                    HttpOnly = true,//xss saldrýlarýný önler
                    SameSite = SameSiteMode.Strict,//Cookie bilgilerinin sadece ayný siteden gelmesini saðlar xss saldýrýsýný önler
                    SecurePolicy = CookieSecurePolicy.Always//Güvenlik açýðý olmaz bu þekilde
                };
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(7);
                options.AccessDeniedPath = new PathString("/Admin/User/AccessDenied");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }
            
            app.UseSession();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();//Kimlik Doðrulamasý

            app.UseAuthorization();//Yetki kontrolü

            app.UseNToastNotify();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(name: "Admin", areaName: "Admin", pattern: "Admin/{controller=Home}/{action=Index}/{id?}");//
                endpoints.MapControllerRoute(name: "User", pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapDefaultControllerRoute();//
            });
        }
    }
}
