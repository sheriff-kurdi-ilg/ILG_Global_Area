
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
            // ILG_GlobalResources.Invalid_Email_Address_
            //ResourceManager resourceManager =
            //new ResourceManager("Resources.xxx", Assembly.Load("App_GlobalResources"));
            //string myString = resourceManager.GetString("StringKey");
        }

        public int ID { get; set; }

        public string PreferredLanguage { get; set; }

        [Required(ErrorMessageResourceName = "Email_Required_", ErrorMessageResourceType = typeof(ILGResources))]

        public string Email { get; set; }
        public bool? IsEnabled { get; set; }
    }
}
