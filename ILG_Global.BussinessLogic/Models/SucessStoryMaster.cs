using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.BussinessLogic.Models
{
    public class SucessStoryMaster
    {
        public int ID { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageName { get; set; }
        public string ImageURL { get; set; }
        public string PDF_FileName { get; set; }
        public bool IsEnabled { get; set; }
    }
}
