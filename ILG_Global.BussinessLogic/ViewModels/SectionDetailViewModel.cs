using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.BackEnd.BussinessLogic.ViewModels
{
    public class SectionDetailViewModel
    {
        public int SectionID { get; set; }
        public string LanguageCode { get; set; }
        public string SectionTitle { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public int SectionMasterID { get; set; }
    }
}
