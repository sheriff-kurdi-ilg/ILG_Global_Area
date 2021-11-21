

using ILG_Global.BussinessLogic.Abstraction;
using ILG_Global.BussinessLogic.Abstraction.Repositories;

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
        

        #region DI

        public IHtmlContentDetailRepository HtmlContentDetailRepository { get; }
        public IOurServiceDetailRepository OurServiceDetailRepository { get; }
        public ISucessStoryDetailRepository SucessStoryDetailRepository { get; }
        public IContactInformationDetailRepository ContactInformationDetailRepository { get; }
        public INewsLetterSubscribeRepository NewsLetterSubscribeRepository { get; set; }
        private IImageDetailRepository ImageDetailRepository;
        private IImageMasterRepository ImageMasterRepository;

        public HomeController(
            IHtmlContentDetailRepository htmlContentDetailRepository,
            IOurServiceDetailRepository ourServiceDetailRepository,
            ISucessStoryDetailRepository sucessStoryDetailRepository,
            IContactInformationDetailRepository contactInformationDetailRepository,
            INewsLetterSubscribeRepository newsLetterSubscribeRepository,
            IImageDetailRepository imageDetailRepository,
            IImageMasterRepository imageMasterRepository
            )
        {
            this.HtmlContentDetailRepository = htmlContentDetailRepository;
            this.OurServiceDetailRepository = ourServiceDetailRepository;
            this.SucessStoryDetailRepository = sucessStoryDetailRepository;
            this.ContactInformationDetailRepository = contactInformationDetailRepository;
            this.NewsLetterSubscribeRepository = newsLetterSubscribeRepository;
            this.ImageDetailRepository = imageDetailRepository;
            this.ImageMasterRepository = imageMasterRepository;
        }

        #endregion

        #region  Index 

        public async Task<ActionResult> Index()
        {

            // HtmlContentDetail oHtmlContentDetail = new HtmlContentDetail();
            // oHtmlContentDetail.HtmlContentMaster.ImageMasters[0]

            HomePageVM oHomePageVM = new HomePageVM();

            oHomePageVM.LeaderBoardSectionHeaderContent = await HtmlContentDetailRepository.SelectByIdAsync(1, "en");
            //  oHomePageVM.OurServiceDetails = OurServiceDetailRepository.

            oHomePageVM.OurServices = await oOurserviceViewModelCreate();

            oHomePageVM.SuccessStoriesViewModel = oSuccessStoriesViewModelCreate();


            oHomePageVM.ContactUsSectionViewModel = await oContactUsViewModelCreate();

            oHomePageVM.NewsLetterSubscribe = new NewsLetterSubscribe();

          //  SaveCurrentCultureToCookie(culture);
            return View(oHomePageVM);
        }

        private SuccessStoriesVM oSuccessStoriesViewModelCreate()
        {
            SuccessStoriesVM oSuccessStoriesVM = new SuccessStoriesVM();

            oSuccessStoriesVM.SuccessStoriesSectionHeaderContent = HtmlContentDetailRepository.SelectByIdAsync(3, "en").Result;
            oSuccessStoriesVM.SucessStoryDetails = SucessStoryDetailRepository.SelectAllAsync("en").Result;

            return oSuccessStoriesVM;
        }

        private async Task<List<OurServiceVM>> oOurserviceViewModelCreate()
        {
            List<OurServiceDetail> lOurServiceDetails = await OurServiceDetailRepository.SelectAllAsync("en");
            List<OurServiceVM> lOurServiceVMs = new List<OurServiceVM>();

            List<ImageDetail> lImageDetails = await ImageDetailRepository.SelectAll("en");

            foreach (OurServiceDetail oOurServiceDetail in lOurServiceDetails)
            {
                List<ImageDetail> lCurrentServiceImageDetails =
                    lImageDetails.Where(m =>
                        m.ImageMaster.OurServiceMasterID == oOurServiceDetail.OurServiceID &&
                        m.LanguageCode == oOurServiceDetail.LanguageCode).OrderBy(m => m.ImageID).ToList();

                OurServiceVM oOurServiceVM = oOurServiceVMCreate(oOurServiceDetail, lCurrentServiceImageDetails);
                lOurServiceVMs.Add(oOurServiceVM);
            }

            return await Task.FromResult(lOurServiceVMs);
        }

        private OurServiceVM oOurServiceVMCreate(OurServiceDetail oOurServiceDetail, List<ImageDetail> lImageDetails)
        {
            OurServiceVM oOurServiceVM = new OurServiceVM();

            oOurServiceVM.OurServiceID = oOurServiceDetail.OurServiceID;
            oOurServiceVM.LanguageCode = oOurServiceDetail.LanguageCode;
            oOurServiceVM.Title = oOurServiceDetail.Title;
            oOurServiceVM.SubTitle = oOurServiceDetail.SubTitle;
            oOurServiceVM.Summary = oOurServiceDetail.Summary;
            oOurServiceVM.Description = oOurServiceDetail.Description;
            oOurServiceVM.ImageDetails = lImageDetails;

            return oOurServiceVM;
        }



        private async Task<ContactUsSectionVM> oContactUsViewModelCreate()
        {
            ContactUsSectionVM oContactUsSectionVM = new ContactUsSectionVM();

            oContactUsSectionVM.ContactUsSectionHeaderContent = HtmlContentDetailRepository.SelectByIdAsync(4, "en").Result;
            oContactUsSectionVM.ContactInformationDetails = ContactInformationDetailRepository.SelectAllAsync("en").Result;

            return await Task.FromResult(oContactUsSectionVM);
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
            SaveCurrentCultureToCookie(culture);
            return LocalRedirect(returnUrl);
        }


        [HttpPost]
        public IActionResult SubscribeToNewsLetter(NewsLetterSubscribe newsLetterSubscribe)
        {
            NewsLetterSubscribeRepository.Insert(newsLetterSubscribe);
            return RedirectToAction(nameof(Index));
        }


        private void SaveCurrentCultureToCookie(string culture)
        {
            Response.Cookies.Append(
               CookieRequestCultureProvider.DefaultCookieName,
               CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
               new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
               );
        }

    }
}
