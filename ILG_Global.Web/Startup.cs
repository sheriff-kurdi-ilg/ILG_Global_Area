using ILG_Global.BussinessLogic.Abstraction.Repositories;
using ILG_Global.BussinessLogic.Abstraction.Services;
using ILG_Global.DataAccess;
using ILG_Global.BackEnd.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;


namespace ILG_Global.BackEnd.Web
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
            // services.AddRazorPages();
            services.AddMvc();

            services.AddDbContext<ILG_GlobalContext>(opt => opt.UseSqlServer(
                Configuration.GetConnectionString("ILG_GlobalConnectionString")));

            services.AddScoped<IHtmlContentDetailRepository, HtmlContentDetailRepository>();
            services.AddScoped<IImageDetailRepository, ImageDetailRepository>();
            services.AddScoped<ISectionDetailRepository, SectionDetailRepository>();
            services.AddScoped<IImageMasterRepository, ImageMasterRepository>();
            services.AddScoped<ISectionMasterRepository, SectionMasterRepository>();

            services.AddScoped<IImageDetailService, ImageDetailService>();
            services.AddScoped<ISectionDetailService, SectionDetailService>();
            services.AddScoped<IImageMasterService, ImageMasterService>();
            services.AddScoped<ISectionMasterService, SectionMasterService>();

            services.AddSwaggerGen();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ILG_Global API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}

                    }
                });
            });

            services.AddControllersWithViews();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();

                app.UseSwaggerUI(c =>
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ILG_Global API V1")
                );
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                             name: "default",
                             pattern: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
