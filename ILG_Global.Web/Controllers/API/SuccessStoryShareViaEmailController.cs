using ILG_Global.BussinessLogic.Abstraction.Repositories;
using ILG_Global.BussinessLogic.Abstraction.Services;
using ILG_Global.BussinessLogic.Models;
using ILG_Global.BussinessLogic.Resources;
using ILG_Global.BussinessLogic.Services;
using ILG_Global.BussinessLogic.ViewModels.API;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ILG_Global.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuccessStoryShareViaEmailController : ControllerBase
    {
        public IEmailRepository EmailRepository { get; }
        public MailService MailService { get; }
        public IILG_PathProvider ILG_PathProvider { get; }
        public object ILG_GlobalResources { get; private set; }

        #region MyRegion
        public SuccessStoryShareViaEmailController(
            IEmailRepository emailRepository,
            MailService mailService,
            IILG_PathProvider iLG_PathProvider)
        {
            EmailRepository = emailRepository;
            MailService = mailService;
            ILG_PathProvider = iLG_PathProvider;
        }
        #endregion


        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public async Task<SuccessStoryShareViaEmailResponse>  Post([FromBody] SuccessStoryShareViaEmailRequest oSuccessStoryShareViaEmailRequest)
        {
            var x = System.Threading.Thread.CurrentThread.CurrentCulture;

            SuccessStoryShareViaEmailResponse oSuccessStoryShareViaEmailResponse = new SuccessStoryShareViaEmailResponse(); 

            try
            {
                ShareViaEmailSubscriber oShareViaEmailSubscriber = new ShareViaEmailSubscriber { EmailAddress = oSuccessStoryShareViaEmailRequest.SuccessStoryEmail };

                await EmailRepository.Insert(oShareViaEmailSubscriber);

                // get sucess story object
                // concatnate pdf file path from admin 
                // attach the file to the mail below.

                string sFilePath = ILG_PathProvider.MapPath("/UserFiles/PDF/SamplePDF1.pdf");

                Attachment oAttachment = new Attachment(sFilePath); ;

                await MailService.Send(oSuccessStoryShareViaEmailRequest.SuccessStoryEmail, "Greeting From ILG", "You have a document shared from ILG, please find it.", oAttachment);


                oSuccessStoryShareViaEmailResponse =
                    new SuccessStoryShareViaEmailResponse {
                        SubscriptionID = oShareViaEmailSubscriber.ID,
                        IsSucceeded = oShareViaEmailSubscriber.ID != 0,
                        UserMessage = oShareViaEmailSubscriber.ID != 0 ? ILGResources.Your_request_Saved_Successfully_ : ILGResources.An_Error_has_occurred_while_saving_your_request_
                    };
            }
            catch (Exception oException)
            {
                throw oException;
            }

            return  oSuccessStoryShareViaEmailResponse;
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
