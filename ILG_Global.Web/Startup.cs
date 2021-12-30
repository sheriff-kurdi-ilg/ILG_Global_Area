using ILG_Global.BussinessLogic.Abstraction.Repositories;
using ILG_Global_Admin.BussinessLogic.Abstraction.Repositories;

using ILG_Global.BussinessLogic.Abstraction.Services;
using ILG_Global_Admin.BussinessLogic.Abstraction.Services;

using ILG_Global.BussinessLogic.Services;

using ILG_Global.DataAccess;
using ILG_Global_Admin.DataAccess;

using ILG_Global.Web.Tools;
using Microsoft.AspNetCore.Builder;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using ILG_Global_Admin.BussinessLogic.Services;
using ILG_Global_Admin.BussinessLogic.Models;
using Microsoft.AspNetCore.Identity;
using ILG_Global_Admin.Web.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;

namespace ILG_Global.Web
{
    public class Startup
    {
        public static IConfiguration StaticConfiguration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            StaticConfiguration = configuration;
        }

        public IConfiguration Configuration { get; }
        public object MethodRules { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddDbContext<ILG_GlobalContext>(opt => opt.UseSqlServer(
                Configuration.GetConnectionString("ILG_GlobalConnectionString")));
            
            services.AddDbContext<ILG_Global_AdminContext>(opt => opt.UseSqlServer(
                Configuration.GetConnectionString("ILG_GlobalConnectionString")));

            services.AddIdentity<ApplicationUser, IdentityRole>
              (options =>
              {
                  options.SignIn.RequireConfirmedAccount = true;
                  options.Password.RequireUppercase = false;
                  options.Password.RequireLowercase = false;
                  options.SignIn.RequireConfirmedEmail = false;
                  options.SignIn.RequireConfirmedPhoneNumber = false;
                  options.SignIn.RequireConfirmedAccount = false;

              })
              .AddEntityFrameworkStores<ILG_Global_AdminContext>();

            services.ConfigureApplicationCookie(options =>
            {

                options.AccessDeniedPath = new PathString("/Account/AccessDenied");
                options.Cookie.Name = "Cookie";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(720);
                options.LoginPath = new PathString("/Admin/Account/Login");
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;

            });


            #region front_repositories
            services.AddScoped<BussinessLogic.Abstraction.Repositories.IHtmlContentDetailRepository, DataAccess.HtmlContentDetailRepository>();
            services.AddScoped<BussinessLogic.Abstraction.Repositories.IImageDetailRepository, DataAccess.ImageDetailRepository>();
            services.AddScoped<BussinessLogic.Abstraction.Repositories.IImageMasterRepository, DataAccess.ImageMasterRepository>();
            services.AddScoped<BussinessLogic.Abstraction.Repositories.IOurServiceDetailRepository, DataAccess.OurServiceDetailRepository>();
            services.AddScoped<BussinessLogic.Abstraction.Repositories.ISucessStoryDetailRepository, DataAccess.SucessStoryDetailRepository>();
            services.AddScoped<BussinessLogic.Abstraction.Repositories.IImageDetailRepository, DataAccess.ImageDetailRepository>();
            services.AddScoped<BussinessLogic.Abstraction.Repositories.IImageMasterRepository, DataAccess.ImageMasterRepository>();
            services.AddScoped<BussinessLogic.Abstraction.Repositories.INewsLetterSubscribeRepository, DataAccess.NewsLetterSubscribeRepository>();
            services.AddScoped<BussinessLogic.Abstraction.Repositories.IEmailRepository, EmailRepository>();
            #endregion

            #region admin_repositories
            services.AddScoped<ILG_Global_Admin.BussinessLogic.Abstraction.Repositories.IHtmlContentDetailRepository, ILG_Global_Admin.DataAccess.HtmlContentDetailRepository>();
            services.AddScoped<ILG_Global_Admin.BussinessLogic.Abstraction.Repositories.IHtmlContentMasterRepository, ILG_Global_Admin.DataAccess.HtmlContentMasterRepository>();
            services.AddScoped<ILG_Global_Admin.BussinessLogic.Abstraction.Repositories.IImageDetailRepository, ILG_Global_Admin.DataAccess.ImageDetailRepository>();
            services.AddScoped<ILG_Global_Admin.BussinessLogic.Abstraction.Repositories.IImageMasterRepository, ILG_Global_Admin.DataAccess.ImageMasterRepository>();
            services.AddScoped<ILG_Global_Admin.BussinessLogic.Abstraction.Repositories.IOurServiceDetailRepository, ILG_Global_Admin.DataAccess.OurServiceDetailRepository>();
            services.AddScoped<ILG_Global_Admin.BussinessLogic.Abstraction.Repositories.IOurServiceMasterRepository, ILG_Global_Admin.DataAccess.OurServiceMasterRepository>();
            services.AddScoped<ILG_Global_Admin.BussinessLogic.Abstraction.Repositories.ISucessStoryDetailRepository, ILG_Global_Admin.DataAccess.SucessStoryDetailRepository>();
            services.AddScoped<ILG_Global_Admin.BussinessLogic.Abstraction.Repositories.ISucessStoryMasterRepository, ILG_Global_Admin.DataAccess.SucessStoryMasterRepository>();
            services.AddScoped<ILG_Global_Admin.BussinessLogic.Abstraction.Repositories.IImageDetailRepository, ILG_Global_Admin.DataAccess.ImageDetailRepository>();
            services.AddScoped<ILG_Global_Admin.BussinessLogic.Abstraction.Repositories.IImageMasterRepository, ILG_Global_Admin.DataAccess.ImageMasterRepository>();
            services.AddScoped<ILG_Global_Admin.BussinessLogic.Abstraction.Repositories.INewsLetterSubscribeRepository, ILG_Global_Admin.DataAccess.NewsLetterSubscribeRepository>();
            services.AddScoped<ILG_Global_Admin.BussinessLogic.Abstraction.Repositories.IContactUsMasterRepository, ILG_Global_Admin.DataAccess.ContactUsMasterRepository>();
            services.AddScoped<ILG_Global_Admin.BussinessLogic.Abstraction.Repositories.IContactUsDetailRepository, ILG_Global_Admin.DataAccess.ContactUsDetailRepository>();

            services.AddScoped<IApplicationUserService, ApplicationUserService>();


            services.AddScoped<ISuccessStoryService, SuccessStoryService>();
            services.AddScoped<IOurServicesService, OurServicesService>();
            services.AddScoped<IContactUsService, ContactUsService>();
            services.AddScoped<IHtmlContentService, HtmlContentService>();
            services.AddScoped<IApplicationUserService, ApplicationUserService>();

            #endregion


            services.AddScoped<IContactInformationDetailRepository, ContactInformationDetailRepository>();


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<CultureProvider>();
            services.AddScoped<MailService>();
            services.AddSingleton<IILG_PathProvider, ILG_PathProvider>();




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
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IConfiguration configuration)
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



            var options = new RewriteOptions()
                .AddRedirect(@"en$", "en/")
                .AddRedirect(@"ar$", "ar/");
            app.UseRewriter(options);
           

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            RequestLocalizationOptions RequestLocalizationOptions = new RequestLocalizationOptions();

            RequestLocalizationOptions.SupportedCultures = RequestLocalizationOptions.SupportedUICultures =
              new CultureInfo[] { new CultureInfo("en"),new CultureInfo("ar") }.ToList();

            RequestLocalizationOptions.DefaultRequestCulture = new RequestCulture(configuration["localization:DefaultLanguge"]);




            RequestLocalizationOptions.RequestCultureProviders.Insert(0, new RouteValueRequestCultureProvider() { Options = RequestLocalizationOptions });

           
            app.UseRequestLocalization(RequestLocalizationOptions);

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapAreaControllerRoute(
                   name: "MyAreaAdmin",
                   areaName: "Admin",
                   pattern: "Admin/{controller=Home}/{action=Index}/{id?}");


                endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{culture}/{controller=Home}/{action=Index}/{id?}",
                        defaults: new { culture = "ar", controller = "Home", action = "Index" });

            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapAreaControllerRoute(
            //   name: "MyAreaAdmin",
            //   areaName: "Admin",
            //   pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

            //    endpoints.MapControllerRoute(
            //     name: "Calt",
            //     pattern: "{culture}",
            //     defaults: new { culture = "ar", controller = "Home", action = "Index" });
            //    **********************

            //    endpoints.MapControllerRoute(

            //                 name: "default",
            //                 pattern: "{culture}/{controller=Home}/{action=Index}/{id?}",
            //                 defaults: new { culture = "ar", controller = "Home", action = "Index" });
            //    ***************


            //});


            //app.UseMvc(configureRoutes =>
            //{
            //    configureRoutes.MapRoute(
            //        name: "Default", 
            //        template: "{culture}/{controller}/{action}/{id?}", 
            //        defaults: new { culture = "", controller = "Home", action = "Index" });
            //});

            //app.UseMvc(configureRoutes =>
            //{
            //    configureRoutes.MapRoute(
            //        name: "Default",
            //        template: "admin/{controller}/{action}/{id?}",
            //        defaults: new { culture = "", controller = "Home", action = "Index" });
            //});
        }
    }
}
