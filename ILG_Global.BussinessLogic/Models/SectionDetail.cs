using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.BussinessLogic.Models
{
    public class SectionDetail
    {
        public int ID { get; set; }

        public string LanguageCode { get; set; }

        [ForeignKey("LanguageCode")]
        public Language Language { get; set; }


        [ForeignKey("SectionMaster")]
        public int SectionMasterID { get; set; }
        public SectionMaster SectionMaster { get; set; }

        public string SectionTitle { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
    }
}
