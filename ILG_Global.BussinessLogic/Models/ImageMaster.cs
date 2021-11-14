using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.BussinessLogic.Models { 
    public class ImageMaster
    {
        public int ID { get; set; }

        //[ForeignKey("HtmlContentMaster")]
        public int? HtmlContentMasterID { get; set; }

        [ForeignKey("OurServiceMasterID")]
        public OurServiceMaster OurServiceMaster { get; set; }
        public int? OurServiceMasterID { get; set; }
        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool IsEnabled { get; set; }
        public List<ImageDetail> ImageDetails { get; set; }

    }
}
