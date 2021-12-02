using ILG_Global.BussinessLogic.Abstraction.Repositories;
using ILG_Global.BussinessLogic.Models;
using ILG_Global.BussinessLogic.ViewModels;
using ILG_Global.Web.Tools;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILG_Global.Web.Controllers
{
    public class ServicesController : Controller
    {
        #region DI

        public IHtmlContentDetailRepository HtmlContentDetailRepository { get; }
        public IOurServiceDetailRepository OurServiceDetailRepository { get; }
        public ISucessStoryDetailRepository SucessStoryDetailRepository { get; }
        public IContactInformationDetailRepository ContactInformationDetailRepository { get; }
        public INewsLetterSubscribeRepository NewsLetterSubscribeRepository { get; set; }
        private IImageDetailRepository ImageDetailRepository { get; set; }
        private IImageMasterRepository ImageMasterRepository { get; set; }
        private IEmailRepository EmailRepository { get; set; }

        private CultureProvider CultureProvider { get; set; }


        public ServicesController(
            IHtmlContentDetailRepository htmlContentDetailRepository,
            IOurServiceDetailRepository ourServiceDetailRepository,
            ISucessStoryDetailRepository sucessStoryDetailRepository,
            IContactInformationDetailRepository contactInformationDetailRepository,
            INewsLetterSubscribeRepository newsLetterSubscribeRepository,
            IImageDetailRepository imageDetailRepository,
            IImageMasterRepository imageMasterRepository,
            IEmailRepository emailRepository,
            CultureProvider CultureProvider
            )
        {
            this.HtmlContentDetailRepository = htmlContentDetailRepository;
            this.OurServiceDetailRepository = ourServiceDetailRepository;
            this.SucessStoryDetailRepository = sucessStoryDetailRepository;
            this.ContactInformationDetailRepository = contactInformationDetailRepository;
            this.NewsLetterSubscribeRepository = newsLetterSubscribeRepository;
            this.ImageDetailRepository = imageDetailRepository;
            this.ImageMasterRepository = imageMasterRepository;
            this.EmailRepository = emailRepository;
            this.CultureProvider = CultureProvider;
        }

        #endregion

        #region Index
        public async Task<ActionResult> Index()
        {
            string sCultureCode = CultureProvider.GetCurrentCulture();
            ServicesPageVM oServicesPageVM = await oServicesPageVMCreate(sCultureCode);

            //ViewData["NewsLetterSubscribe"] = new NewsLetterSubscribe();

            return View(oServicesPageVM);
        }

        private async Task<ServicesPageVM> oServicesPageVMCreate(string sCultureCode)
        {
            ServicesPageVM oServicesPageVM = new ServicesPageVM();

            oServicesPageVM.OurServices = await oOurserviceViewModelCreate(sCultureCode);

            oServicesPageVM.AboutILGSectionVM = await oAboutILGSectionVMCreate(sCultureCode);

            oServicesPageVM.HowWeWorkSectionContentDetail = await HtmlContentDetailRepository.SelectByIdAsync(7, sCultureCode);

            oServicesPageVM.ContactUsSectionViewModel = await oContactUsViewModelCreate(sCultureCode);

            return oServicesPageVM;
        }

        private async Task<List<OurServiceVM>> oOurserviceViewModelCreate(string sCultureCode)
        {
            List<OurServiceDetail> lOurServiceDetails = await OurServiceDetailRepository.SelectAllAsync(sCultureCode);
            List<OurServiceVM> lOurServiceVMs = new List<OurServiceVM>();

            List<ImageDetail> lImageDetails = await ImageDetailRepository.SelectAll(sCultureCode);

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

        private async Task<AboutILGSectionVM> oAboutILGSectionVMCreate(string sCultureCode)
        {
            AboutILGSectionVM oAboutILGSectionVM = new AboutILGSectionVM();

            oAboutILGSectionVM.AboutILGSectionContentDetail = await HtmlContentDetailRepository.SelectByIdAsync(6, sCultureCode);
            oAboutILGSectionVM.AboutILGSectionImageDetail = await ImageDetailRepository.SelectById(sCultureCode, 8);

            return oAboutILGSectionVM;
        }

        private async Task<ContactUsSectionVM> oContactUsViewModelCreate(string sCultureCode)
        {
            ContactUsSectionVM oContactUsSectionVM = new ContactUsSectionVM();

            oContactUsSectionVM.ContactUsSectionHeaderContent = HtmlContentDetailRepository.SelectByIdAsync(4, sCultureCode).Result;
            oContactUsSectionVM.ContactInformationDetails = ContactInformationDetailRepository.SelectAllAsync(sCultureCode).Result;

            return await Task.FromResult(oContactUsSectionVM);
        }

        #endregion
    }
}
