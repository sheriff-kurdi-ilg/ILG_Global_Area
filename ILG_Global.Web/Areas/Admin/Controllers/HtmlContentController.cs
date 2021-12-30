using ILG_Global_Admin.BussinessLogic.Abstraction.Services;
using ILG_Global_Admin.BussinessLogic.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ILG_Global_Admin.Web.Controllers
{
    [Authorize]
    [Area("admin")]

    public class HtmlContentController : Controller
    {
        private readonly IHtmlContentService htmlContentService;
        private readonly IHostEnvironment hostEnvironment;

        public HtmlContentController(IHtmlContentService htmlContentService, IHostEnvironment hostEnvironment)
        {
            this.htmlContentService = htmlContentService;
            this.hostEnvironment = hostEnvironment;
        }
        // GET: OurServicesController
        public async Task<ActionResult> Index()
        {
            
            List<HtmlContentVM> HtmlContentVMs = await htmlContentService.SelectAllAsync("en");
            return View(HtmlContentVMs);
        }

        // GET: OurServicesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            HtmlContentVM HtmlContentVM = await htmlContentService.SelectByIdAsync(id);
            return View(HtmlContentVM);
        }

        // GET: OurServicesController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: OurServicesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(HtmlContentVM HtmlContentVM)
        {
            try
            {

                string uploadsFolder = Path.Combine(hostEnvironment.ContentRootPath, "wwwroot/Uploads/Ar/HtmlContent");


                string uniqFileNameAr = Guid.NewGuid().ToString() + "_" + Path.GetFileName(HtmlContentVM.ImageAr.FileName);
                string filePathAr = Path.Combine(uploadsFolder, uniqFileNameAr);
                HtmlContentVM.ImageAr.CopyTo(new FileStream(filePathAr, FileMode.Create));
                HtmlContentVM.ImageURLAr = uniqFileNameAr;

                string uniqFileNameEn = Guid.NewGuid().ToString() + "_" + Path.GetFileName(HtmlContentVM.ImageEn.FileName);
                string filePathEn = Path.Combine(uploadsFolder, uniqFileNameEn);
                HtmlContentVM.ImageEn.CopyTo(new FileStream(filePathEn, FileMode.Create));
                HtmlContentVM.ImageURLEn = uniqFileNameEn;

                await htmlContentService.Insert(HtmlContentVM);
                TempData["Message"] = "Created!";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OurServicesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            HtmlContentVM HtmlContentVM = await htmlContentService.SelectByIdAsync(id);
            return View(HtmlContentVM);
        }

        // POST: OurServicesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(HtmlContentVM HtmlContentVM)
        {
            try
            {
                if (HtmlContentVM.ImageAr != null)
                {
                    string uploadsFolder = Path.Combine(hostEnvironment.ContentRootPath, "wwwroot/Uploads/HtmlContent");
                    string uniqFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(HtmlContentVM.ImageAr.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqFileName);
                    HtmlContentVM.ImageAr.CopyTo(new FileStream(filePath, FileMode.Create));
                    HtmlContentVM.ImageURLAr = uniqFileName;

                }

                if (HtmlContentVM.ImageEn != null)
                {
                    string uploadsFolder = Path.Combine(hostEnvironment.ContentRootPath, "wwwroot/Uploads/HtmlContent");
                    string uniqFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(HtmlContentVM.ImageEn.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqFileName);
                    HtmlContentVM.ImageEn.CopyTo(new FileStream(filePath, FileMode.Create));
                    HtmlContentVM.ImageURLEn = uniqFileName;

                }

                await htmlContentService.Update(HtmlContentVM);
                TempData["Message"] = "Updated!";
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: OurServicesController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            HtmlContentVM HtmlContentVM = await htmlContentService.SelectByIdAsync(id);

            return View(HtmlContentVM);
        }

        // POST: OurServicesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(HtmlContentVM HtmlContentVM)
        {
            try
            {
                htmlContentService.Delete(HtmlContentVM);
                TempData["Message"] = "Deleted!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        [HttpGet]
        public async Task<IActionResult> ActivationToggle(int id)
        {
            await htmlContentService.ToggleSwtich(id);
            return RedirectToAction("Index");
        }
    }
}
