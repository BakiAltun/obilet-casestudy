using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OBilet.CaseStudy.Infrastructure.ApiServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OBilet.CaseStudy.Infrastructure.MediatR;
using OBilet.CaseStudy.Infrastructure.Services;
using FluentValidation.AspNetCore;

namespace OBilet.CaseStudy.Presentation.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddAuthentication(options =>
            //{

            //}).AddCookie(options =>
            //{
            //    //options.Cookie.
            //});

            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(typeof(HttpGlobalExceptionFilter));
            }).AddRazorRuntimeCompilation();
            services.AddHttpContextAccessor();
            services.AddApiServices()
                    .AddManagers()
                    .AddMediatR();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
