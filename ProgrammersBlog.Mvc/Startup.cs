using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProgrammersBlog.Data.Concrete.EntityFramework.Contexts;
using ProgrammersBlog.Services.AutoMapper.Profiles;
using ProgrammersBlog.Services.Extensions;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProgrammersBlog.Mvc
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ProgrammersBlogContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("ProgrammersConnection")));

            services.AddControllersWithViews().AddRazorRuntimeCompilation().AddJsonOptions(opt=> {

                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            });
            services.AddAutoMapper(typeof(CategoryProfile), typeof(ArticleProfile));
            services.LoadMyServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                //Hata sayfalarýný gösterir
                app.UseStatusCodePages();
            }

            //Static dosyalar için(www)
            app.UseStaticFiles();


            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "Admin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
                );
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
