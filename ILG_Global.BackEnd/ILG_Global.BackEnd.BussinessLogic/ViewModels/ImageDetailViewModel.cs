using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.BackEnd.BussinessLogic.Models
{
    public class ImageDetailViewModel
    {
        public int ID { get; set; }
        public int LanguageCode { get; set; }
        public int ImageMasterID { get; set; }
        public string Name { get; set; }
        public string  Title { get; set; }
        public string AlternateText { get; set; }
    }
}
