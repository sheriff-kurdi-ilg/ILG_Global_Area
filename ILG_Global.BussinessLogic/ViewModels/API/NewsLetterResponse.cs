using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.BussinessLogic.ViewModels.API
{
    public class NewsLetterResponse
    {
        public bool status { get; set; }
        public string code { get; set; }

        public string message { get; set; }

        public object data { get; set; }
    }


}
