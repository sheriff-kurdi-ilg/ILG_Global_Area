using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.BackEnd.BussinessLogic.Models
{
    public class ImageDetail
    {
        public int ID { get; set; }

        [ForeignKey("Master")]
        public int ImageID { get; set; }
        public ImageMaster Master { get; set; } 

        
        [ForeignKey("Section")]
        public int SectionID { get; set; }
        public SectionDetail Section { get; set; }




        public string Name  { get; set; }

        public string LanguageCode { get; set; }

        public string  Title { get; set; }

        public string AlternateText { get; set; }
    }
}
