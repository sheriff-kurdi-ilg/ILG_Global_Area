using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILG_Global.Web.Tools
{
    public class CultureProvider
    {
        
        private readonly IHttpContextAccessor _httpContextAccessor;

        public string CurrentCulture { get; set; }
        public CultureProvider(IHttpContextAccessor _httpContextAccessor)
        {
            this._httpContextAccessor = _httpContextAccessor;
        }

        public string GetCurrentCulture()
        {
            IRequestCultureFeature RequesCulturetFeature = _httpContextAccessor.HttpContext.Features.Get<IRequestCultureFeature>();
            string currentCulture = RequesCulturetFeature.RequestCulture.Culture.Name;
            return currentCulture;
        }
    }
}
