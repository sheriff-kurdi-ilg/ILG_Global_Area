using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.BussinessLogic.Models
{
    public class ImageDetail
    {

        public string LanguageCode { get; set; }
        [ForeignKey("LanguageCode")]
        public Language Language { get; set; }

        [ForeignKey("ImageMaster")]
        public int ImageMasterID { get; set; }
        public ImageMaster ImageMaster { get; set; } 



        public string Name  { get; set; }

        public string  Title { get; set; }

        public string AlternateText { get; set; }
    }
}
