using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ILG_Global.Web.Tools
{
    public class MyHttpContextAccessor : IHttpContextAccessor
    {
        private static AsyncLocal<HttpContext> _httpContextCurrent = new AsyncLocal<HttpContext>();
        HttpContext IHttpContextAccessor.HttpContext { get => _httpContextCurrent.Value; set => _httpContextCurrent.Value = value; }
    }
}
