using ILG_Global.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILG_Global.Web.Controllers
{
    public class AboutController : Controller
    {
        //public ICaseProcessDetailRepository CaseProcessDetailRepository { get; }

        //public AboutController(ICaseProcessDetailRepository caseProcessDetailRepository)
        //{
        //    CaseProcessDetailRepository = caseProcessDetailRepository;
        //}


        public IActionResult Index()
        {

            return View();
        }
    }
}
