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

        public List<OurServiceDetail> OurServiceDetails { get; set; }
    }
}
