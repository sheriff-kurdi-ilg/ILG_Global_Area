using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILG_Global.Web.Controllers
{
    public class _BaseController: Controller
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
    }
}
