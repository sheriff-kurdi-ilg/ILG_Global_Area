using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.BackEnd.BussinessLogic.Models
{
    public class SectionDetail
    {
        public int ID { get; set; }
        public string LanguageCode { get; set; }


        [ForeignKey("Master")]
        public int MasterID { get; set; }
        public SectionMaster Master { get; set; }

        public string SectionTitle { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
    }
}
