using ILG_Global.BussinessLogic.Abstraction;
using ILG_Global.BussinessLogic.Abstraction.Repositories;
using ILG_Global.BussinessLogic.Services;
using ILG_Global.DataAccess;
using ILG_Global.Web.Tools;
using Microsoft.AspNetCore.Builder;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.AspNetCore.Mvc.Razor;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ILG_Global.Web
{
    public class Startup
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddDbContext<ILG_GlobalContext>(opt => opt.UseSqlServer(
                Configuration.GetConnectionString("ILG_GlobalConnectionString")));

            services.AddScoped<IHtmlContentDetailRepository, HtmlContentDetailRepository>();
            services.AddScoped<IImageDetailRepository, ImageDetailRepository>();
            services.AddScoped<IImageMasterRepository, ImageMasterRepository>();

            services.AddScoped<IOurServiceDetailRepository, OurServiceDetailRepository>();
            services.AddScoped<ISucessStoryDetailRepository, SucessStoryDetailRepository>();
            services.AddScoped<IContactInformationDetailRepository, ContactInformationDetailRepository>();
            services.AddScoped<IImageDetailRepository, ImageDetailRepository>();
            services.AddScoped<IImageMasterRepository, ImageMasterRepository>();

            services.AddScoped<INewsLetterSubscribeRepository, NewsLetterSubscribeRepository>();
            services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IEmailRepository, EmailRepository>();





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


            services.AddLocalization(opts => opts.ResourcesPath = "Resources");

            services.AddMvc(opts=>opts.EnableEndpointRouting=false).AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();

           
        }






        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //var LocaOptions = app.ApplicationServices.GetServices<IOptions<RequestLocalizationOptions>>();
            
            //app.UseRequestLocalization(LocaOptions.Select(ff => ff.Value).SingleOrDefault());

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

            RequestLocalizationOptions RequestLocalizationOptions = new RequestLocalizationOptions();

            RequestLocalizationOptions.SupportedCultures = RequestLocalizationOptions.SupportedUICultures =
              new CultureInfo[] { new CultureInfo("en"),new CultureInfo("ar") }.ToList();
            
           
            
            RequestLocalizationOptions.RequestCultureProviders.Insert(0, new RouteValueRequestCultureProvider() { Options = RequestLocalizationOptions });

           
            app.UseRequestLocalization(RequestLocalizationOptions);

            app.UseStaticFiles();

            app.UseRouting();


            app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //                 name: "default",
            //                 pattern: "/{controller=Home}/{action=Index}/{id?}/{culture?}");

            //});


            app.UseMvc(configureRoutes =>
            {
                configureRoutes.MapRoute(name: "Default", template: "{culture}/{controller}/{action}/{id?}", defaults: new { culture = "", controller = "Home", action = "Index" });
            });

        }
    }
}
