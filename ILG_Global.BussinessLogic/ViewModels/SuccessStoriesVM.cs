using ILG_Global.BussinessLogic.Models;
using ILG_Global.BussinessLogic.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.BussinessLogic.ViewModels
{
    public class SuccessStoriesVM
    {
        public HtmlContentDetail SuccessStoriesSectionHeaderContent { get; set; }

        public List<SucessStoryDetail>  SucessStoryDetails { get; set; }

        public string PreferredLanguage { get; set; }

        [Required(ErrorMessageResourceName = "EmailRequiredValidateMessage", ErrorMessageResourceType = typeof(ILGSharedResource))]
        //[RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
        //    ErrorMessageResourceName = "EmailFormatValidate", ErrorMessageResourceType = typeof(ILG_Global.BussinessLogic.Resources.ILGSharedResource))]
        public string SuccessStoryUserEmail { get; set; }
    }
}
