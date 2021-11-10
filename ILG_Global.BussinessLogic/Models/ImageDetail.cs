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
        [ForeignKey("ImageMaster")]
        public int ImageID { get; set; }
        public ImageMaster ImageMaster { get; set; }

        public string LanguageCode { get; set; }
        [ForeignKey("LanguageCode")]
        public Language Language { get; set; }

        public string  Title { get; set; }

        public string AlternateText { get; set; }
    }
}
