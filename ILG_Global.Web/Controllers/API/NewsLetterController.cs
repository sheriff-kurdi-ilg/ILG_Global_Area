using ILG_Global.BussinessLogic.Abstraction.Repositories;
using ILG_Global.BussinessLogic.Models;
using ILG_Global.BussinessLogic.Resources;
using ILG_Global.BussinessLogic.Services;
using ILG_Global.BussinessLogic.ViewModels.API;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILG_Global.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsLetterController : ControllerBase
    {
        public INewsLetterSubscribeRepository NewsLetterSubscribeRepository { get; }
        public MailService MailService { get; }

        public NewsLetterController(INewsLetterSubscribeRepository newsLetterSubscribeRepository, MailService mailService)
        {
            NewsLetterSubscribeRepository = newsLetterSubscribeRepository;
            MailService = mailService;

        }

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
        public async Task<NewsLetterResponse>  Post([FromBody] NewsLetterRequest oNewsLetterRequest)
        {
            NewsLetterSubscribe oNewsLetterSubscribe = oNewsLetterSubscribeCreate(oNewsLetterRequest);
             NewsLetterSubscribeRepository.Insert(oNewsLetterSubscribe);

             MailService.Send(oNewsLetterRequest.Email, "Greeting From ILG", "You Subscribed to ILG Newsletter.");

            NewsLetterResponse oNewsLetterResponse = oNewsLetterResponseCreate(oNewsLetterSubscribe);

            return oNewsLetterResponse;
        }



        private NewsLetterSubscribe oNewsLetterSubscribeCreate( NewsLetterRequest oNewsLetterRequest)
        {
            NewsLetterSubscribe oNewsLetterSubscribe = new NewsLetterSubscribe();

            oNewsLetterSubscribe.PreferredLanguage = oNewsLetterRequest.LanguageCode;
            oNewsLetterSubscribe.Email = oNewsLetterRequest.Email;

            return oNewsLetterSubscribe;
        }

        private NewsLetterResponse oNewsLetterResponseCreate(NewsLetterSubscribe oNewsLetterSubscribe)
        {
            NewsLetterResponse oNewsLetterResponse = new NewsLetterResponse();

            oNewsLetterResponse.SubscriptionID = oNewsLetterSubscribe.ID;
            oNewsLetterResponse.IsSucceeded = oNewsLetterSubscribe.ID != 0;
            oNewsLetterResponse.UserMessage = oNewsLetterSubscribe.ID != 0 ? ILGResources.You_Subscribed_to_Newsletter_Successfully_ : ILGResources.An_Error_has_occurred_while_saving_your_request_;
  
            return oNewsLetterResponse;
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
