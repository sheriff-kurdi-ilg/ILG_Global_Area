using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ILG_Global.Web.Controllers
{
    public class _BaseController : Controller
    {
        #region Language Change

        //public string CurrentLanguageCode
        //{
        //    get
        //    {
        //        string sLanguageCode = sGetCurrentLanguageCode();
        //        return sLanguageCode;
        //    }
        //}

        //public static string sGetCurrentLanguageCode()
        //{
        //    string sCurrnetLanguageCode = CookieUtility<string>.vReadStringCookie("KbLanguageCode");

        //    if (string.IsNullOrEmpty(sCurrnetLanguageCode))
        //    {
        //        sCurrnetLanguageCode = "en";
        //    }

        //    return sCurrnetLanguageCode;
        //}

        #endregion

        #region Read Cookies

        private readonly IHttpContextAccessor _httpContextAccessor;

        public _BaseController(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {

            string cookieValueFromContext = _httpContextAccessor.HttpContext.Request.Cookies["key"];
            string cookieValueFromReq = Request.Cookies["Key"];

            Set("kay", "Hello from cookie", 10);
            //Delete the cookie object  
            Remove("Key");
            return View();
        }


        public string GetCookieValue(string key)
        {
            return Request.Cookies[key];
        }
        /// <summary>  
        /// set the cookie  
        /// </summary>  
        /// <param name="key">key (unique indentifier)</param>  
        /// <param name="value">value to store in cookie object</param>  
        /// <param name="expireTime">expiration time</param>  
        public void Set(string key, string value, int? expireTime)
        {
            CookieOptions option = new CookieOptions();
            if (expireTime.HasValue)
                option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            else
                option.Expires = DateTime.Now.AddMilliseconds(10);
            Response.Cookies.Append(key, value, option);
        }
        /// <summary>  
        /// Delete the key  
        /// </summary>  
        /// <param name="key">Key</param>  
        public void Remove(string key)
        {
            Response.Cookies.Delete(key);
        }

        #endregion

    }


}
