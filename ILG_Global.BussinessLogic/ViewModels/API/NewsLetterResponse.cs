using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.BussinessLogic.ViewModels.API
{
    public class NewsLetterResponse
    {
        public bool IsSucceeded { get; set; }
        public int SubscriptionID { get; set; }
        public string UserMessage { get; set; }
    }


}
