using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.BussinessLogic.Models
{
    public class CaseProcessDetail
    {
        public int OurServiceID { get; set; }

        public int CaseProcessID { get; set; }
        [ForeignKey("CaseProcessID")]
        public CaseProcessMaster CaseProcessMaster { get; set; }

        public string LanguageCode { get; set; }
        [ForeignKey("LanguageCode")]
        public Language Language { get; set; }

        public string TextLine { get; set; }

    }
}
