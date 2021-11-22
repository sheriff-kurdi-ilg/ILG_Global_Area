using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Web;
// using System.Web.Script.Serialization;

namespace ILG_Global.Web.Tools
{
    public class CookieUtility<T>
    {
        // private static JavaScriptSerializer oJavaScriptSerializer = new JavaScriptSerializer();
        private HttpContextAccessor _httpContextAccessor;

        public CookieUtility(HttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        public void vSaveCookie(T oObjectToSave, string sCookieNameToSaveIn)
        {
            string cookieValueFromContext = _httpContextAccessor.HttpContext.Request.Cookies["key"];

            //HttpCookie oHttpCookie = new HttpCookie(sCookieNameToSaveIn);// Cookie Name

            //oHttpCookie.Value = oJavaScriptSerializer.Serialize(oObjectToSave);
            //oHttpCookie.Expires = DateTime.Now.AddYears(1);

            //HttpContext.Current.Response.Cookies.Add(oHttpCookie);
        }

        //public T vReadCookie(string sCookieNameToReadFrom)
        //{
        //    T cookieValueFromContext = (T)_httpContextAccessor.HttpContext.Request.Cookies["key"];

        //    //read cookie from Request object  
        // return cookieValueFromContext
        //}


        //public static void vSaveCookieAsString(string sStringToSave, string sCookieNameToSaveIn)
        //{
        //    HttpCookie oHttpCookie =
        //        HttpContext.Current.Request.Cookies[sCookieNameToSaveIn] ??
        //        new HttpCookie(sCookieNameToSaveIn);

        //    oHttpCookie.Value = sStringToSave;
        //    oHttpCookie.Expires = DateTime.Now.AddYears(1);

        //    HttpContext.Current.Response.Cookies.Add(oHttpCookie);
        //}

        //public static string vReadStringCookie(string sCookieNameToReadFrom)
        //{
        //    HttpCookie oHttpCookie = HttpContext.Current.Request.Cookies[sCookieNameToReadFrom];

        //    string sSavedValue = oHttpCookie != null ? oHttpCookie.Value : string.Empty;

        //    return sSavedValue;
        //}

    }
}