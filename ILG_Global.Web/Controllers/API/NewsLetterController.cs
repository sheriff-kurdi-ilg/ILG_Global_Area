using ILG_Global.BussinessLogic.Abstraction.Repositories;
using ILG_Global.BussinessLogic.Models;
using ILG_Global.BussinessLogic.ViewModels.API;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ILG_Global.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsLetterController : ControllerBase
    {
        public INewsLetterSubscribeRepository NewsLetterSubscribeRepository { get; }

        public NewsLetterController(INewsLetterSubscribeRepository newsLetterSubscribeRepository)
        {
            NewsLetterSubscribeRepository = newsLetterSubscribeRepository;
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
        public NewsLetterResponse Post([FromBody] NewsLetterRequest oNewsLetterRequest)
        {
            NewsLetterSubscribe oNewsLetterSubscribe = oNewsLetterSubscribeCreate(oNewsLetterRequest);
            NewsLetterSubscribeRepository.Insert(oNewsLetterSubscribe);

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

            if (oNewsLetterSubscribe.ID != 0) 
            {
                oNewsLetterResponse.code = "200";
                oNewsLetterResponse.status = true;
                // for test only.
                if (oNewsLetterSubscribe.PreferredLanguage.ToLower() == "en")
                {
                    oNewsLetterResponse.message = "Your News Letter subscription created Successfully";
                }

                if (oNewsLetterSubscribe.PreferredLanguage.ToLower() == "ar")
                {
                    oNewsLetterResponse.message = "تم الاشتراك فى حدمة رسائلنا الاخبارية بنجاح.";
                }
            }

            oNewsLetterResponse.data = oNewsLetterSubscribe;

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
