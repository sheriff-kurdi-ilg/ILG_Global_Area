using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ILG_Global.Web.Tools
{

    public class RouteValueRequestCultureProvider : RequestCultureProvider
    {
           
        public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            string cultureCode = null;

            if (httpContext.Request.Path.HasValue && httpContext.Request.Path.Value == "/")
                cultureCode = this.GetDefaultCultureCode(httpContext);

            // TODO: make it look more beautiful
            else if (httpContext.Request.Path.HasValue && httpContext.Request.Path.Value.Length >= 4 && httpContext.Request.Path.Value[0] == '/' && httpContext.Request.Path.Value[3] == '/')
            {
                cultureCode = httpContext.Request.Path.Value.Substring(1, 2);

                if (!this.CheckCultureCode(cultureCode))
                    cultureCode = this.GetDefaultCultureCode(httpContext); //throw new HttpException(HttpStatusCode.NotFound);
            }

            else cultureCode = this.GetDefaultCultureCode(httpContext); //throw new HttpException(HttpStatusCode.NotFound);

            // TODO: from the SEO point of view, we should return 404 error code for unknown cultures

            ProviderCultureResult requestCulture = new ProviderCultureResult(cultureCode);

            
            return Task.FromResult(requestCulture);
        }

        private string GetDefaultCultureCode(HttpContext httpContext)
        {
            var CookieCulture= httpContext.Request.Cookies[".AspNetCore.Culture"];
            if (CookieCulture!=null)
            {

                return CookieCulture.Substring(2, 2);
            }
            else
            {
                return this.Options.DefaultRequestCulture.Culture.TwoLetterISOLanguageName;
            }
        }

        private bool CheckCultureCode(string cultureCode)
        {
            return this.Options.SupportedCultures.Select(c => c.TwoLetterISOLanguageName).Contains(cultureCode);
        }
    }

}
