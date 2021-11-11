

using ILG_Global.BussinessLogic.Abstraction;
using ILG_Global.BussinessLogic.Abstraction.Repositories;

﻿using ILG_Global.DataAccess;

using ILG_Global.BussinessLogic.Models;
using ILG_Global.BussinessLogic.ViewModels;
using Microsoft.AspNetCore.Http;


using Microsoft.AspNetCore.Localization;

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILG_Global.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly INewsLetterSubscribeRepository newsLetterSubscribeRepository;

        #region DI

        public IHtmlContentDetailRepository HtmlContentDetailRepository { get; }
        public IOurServiceDetailRepository OurServiceDetailRepository { get; }
        public ISucessStoryDetailRepository SucessStoryDetailRepository { get; }
        public IContactInformationDetailRepository ContactInformationDetailRepository { get; }

        public HomeController(
            IHtmlContentDetailRepository htmlContentDetailRepository,
            IOurServiceDetailRepository ourServiceDetailRepository,
            ISucessStoryDetailRepository sucessStoryDetailRepository,
            IContactInformationDetailRepository  contactInformationDetailRepository
            )
        {

            HtmlContentDetailRepository = htmlContentDetailRepository;
            OurServiceDetailRepository = ourServiceDetailRepository;
            SucessStoryDetailRepository = sucessStoryDetailRepository;
            ContactInformationDetailRepository = contactInformationDetailRepository;

            IHtmlContentDetailRepository htmlContentDetailRepository,
            INewsLetterSubscribeRepository newsLetterSubscribeRepository)
        {

            HtmlContentDetailRepository = htmlContentDetailRepository;
            this.newsLetterSubscribeRepository = newsLetterSubscribeRepository;

        }

        #endregion

        #region  Index 

        public async Task<ActionResult> Index()
        {
            HomePageVM oHomePageVM = new HomePageVM();

            oHomePageVM.LeaderBoardSectionHeaderContent = await HtmlContentDetailRepository.SelectByIdAsync(1, "en");

            oHomePageVM.OurServiceDetails = await OurServiceDetailRepository.SelectAllAsync("en");

            oHomePageVM.SuccessStoriesSectionHeaderContent = await HtmlContentDetailRepository.SelectByIdAsync(3, "en");
            oHomePageVM.SucessStoryDetails = await SucessStoryDetailRepository.SelectAllAsync("en");

            oHomePageVM.ContactUsSectionHeaderContent = await HtmlContentDetailRepository.SelectByIdAsync(4, "en");
            oHomePageVM.ContactInformationDetails = await ContactInformationDetailRepository.SelectAllAsync("en");

            return View(oHomePageVM);
        }

        #endregion

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );
            return LocalRedirect(returnUrl);
        }




        [HttpPost]
        public IActionResult SubscribeToNewsLetter(NewsLetterSubscribe newsLetterSubscribe)
        {
            newsLetterSubscribeRepository.Insert(newsLetterSubscribe);
            return RedirectToAction(nameof(Index));
        }
    }
}
