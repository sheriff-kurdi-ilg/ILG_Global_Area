using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.BackEnd.BussinessLogic.ViewModels
{
    public class ImageMasterViewModel
    {
        public int ID { get; set; }
        public int Width { get; set; }
        public int SectionMasterID { get; set; }
        public int Height { get; set; }
        public bool IsEnabled { get; set; }
    }
}
