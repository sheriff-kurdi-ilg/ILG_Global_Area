using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.BackEnd.BussinessLogic.Models
{
    public class SucessStoryDetail
    {
        public int ID { get; set; }
        public SucessStoryMaster SucessStoryMaster { get; set; }
        public string LanguageCode { get; set; }
        public string Title { get; set; }

    }
}
