using ILG_Global.BussinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.BussinessLogic.ViewModels
{
    public  class OurServiceVM
    {
        public int OurServiceID { get; set; }
        public bool IsEnabled { get; set; }
        public string LanguageCode { get; set; }
        public string ImageURL { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }

        //public List<ImageDetail> ImageDetails { get; set; }
    }
}
