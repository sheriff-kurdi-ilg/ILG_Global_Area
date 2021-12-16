using ILG_Global.BussinessLogic.Resources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Resources;


namespace ILG_Global.BussinessLogic.Models
{
    public class NewsLetterSubscribe
    {
        public NewsLetterSubscribe()
        {
            //ResourceManager resourceManager =
            //new ResourceManager("Resources.xxx", Assembly.Load("App_GlobalResources"));
            //string myString = resourceManager.GetString("StringKey");
        }

        public int ID { get; set; }

        public string PreferredLanguage { get; set; }

        [Required(ErrorMessageResourceName = "EmailRequiredValidateMessage", ErrorMessageResourceType = typeof(ILGSharedResource))]
        //[RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
        //    ErrorMessageResourceName = "EmailFormatValidate", ErrorMessageResourceType = typeof(ILGSharedResource))]

        //[RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
        //    ErrorMessageResourceName = "EmailFormatValidate", ErrorMessageResourceType = typeof(ILGSharedResource))]
        public string Email { get; set; }
        public bool? IsEnabled { get; set; }
    }
}
