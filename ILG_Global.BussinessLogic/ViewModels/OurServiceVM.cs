using ILG_Global.BussinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.BussinessLogic.ViewModels
{
    public  class OurServiceVM
    {
        public IEnumerable<OurServiceDetail> OurServiceDetails { get; set; }
        public List<ImageMaster> ImageMasters { get; set; } = new List<ImageMaster>();
        public List<ImageDetail> ImageDetails { get; set; } = new List<ImageDetail>();
    }
}
