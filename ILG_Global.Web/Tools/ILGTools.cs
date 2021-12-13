using ILG_Global.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Mvc.Rendering
{
    public static class ILGTools
    {
        //private static IWebHostEnvironment HostEnvironment;
        //public IConfiguration Configuration { get; }
        //static HtmlHelperPartialExtensions()
        //{

        //}

        //public HtmlHelperPartialExtensions(IWebHostEnvironment environment, IConfiguration oConfiguration)
        //{
        //    HostEnvironment = environment;
        //    Configuration = oConfiguration;
        //}

        public static string ToCDN_URL( string sFolderPath,string sFilePath)
        {
            string sCDN_DomainName =  Startup.StaticConfiguration.GetSection("CDN_DomainName").Value;
            string filePath = string.Format("{0}/{1}/{2}", sCDN_DomainName, sFolderPath,sFilePath);
            return filePath;
        }

    }
}
