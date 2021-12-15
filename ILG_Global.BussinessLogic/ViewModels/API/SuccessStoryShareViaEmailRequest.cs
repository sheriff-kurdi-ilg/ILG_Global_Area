using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.BussinessLogic.ViewModels.API
{
    public class SuccessStoryShareViaEmailRequest
    {
        public int SuccessStoryID { get; set; }
        public string LanguauageCode { get; set; }
        public string SuccessStoryEmail { get; set; }
    }
}
