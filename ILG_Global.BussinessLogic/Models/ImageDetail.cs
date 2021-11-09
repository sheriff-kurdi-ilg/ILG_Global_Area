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

        [ForeignKey("Language")]
        public int LanguageCode { get; set; }
        public Language Language  { get; set; }

        [ForeignKey("ImageMaster")]
        public int ImageMasterID { get; set; }
        public ImageMaster ImageMaster { get; set; } 



        public string Name  { get; set; }

        public string  Title { get; set; }

        public string AlternateText { get; set; }
    }
}
