using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ILG_Global.Web.Controllers
{
    public class TermsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
