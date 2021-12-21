using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ILG_Global.BussinessLogic.Abstraction.Repositories;
using ILG_Global.BussinessLogic.Models;
using ILG_Global.Web.Tools;
using Microsoft.AspNetCore.Mvc;

namespace ILG_Global.Web.Controllers
{
    public class TermsController : Controller
    {
        #region DI
        public IHtmlContentDetailRepository HtmlContentDetailRepository { get; }
        public CultureProvider CultureProvider { get; }

        public TermsController(
            IHtmlContentDetailRepository htmlContentDetailRepository,
              CultureProvider CultureProvider)
        {
            HtmlContentDetailRepository = htmlContentDetailRepository;
            this.CultureProvider = CultureProvider;
        }

  
        #endregion

        public async Task<IActionResult>  Index()
        {
            string CultureCode = CultureProvider.GetCurrentCulture();
            HtmlContentDetail oHtmlContentDetail = await HtmlContentDetailRepository.SelectByIdAsync(15, CultureCode);
            return View(oHtmlContentDetail);
        }
    }
}
