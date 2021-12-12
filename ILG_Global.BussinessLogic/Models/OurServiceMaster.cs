using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.BussinessLogic.Models
{
    public class OurServiceMaster
    {
        public int ID { get; set; }
        public bool IsEnabled { get; set; }
        [ForeignKey("ImageMastersId")]
        public List<ImageMaster> ImageMasters { get; set; }
        public int ImageMastersId { get; set; }

        public List<OurServiceDetail> OurServiceDetails { get; set; }

        public List<ImageDetail> ImageDetails { get; set; }

        public string ImageURL { get; set; }
        
    }
}
