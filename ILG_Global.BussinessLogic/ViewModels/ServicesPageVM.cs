using ILG_Global.BussinessLogic.Models;

using System.Collections.Generic;

namespace ILG_Global.BussinessLogic.ViewModels
{
    public class ServicesPageVM
    {
        public List<OurServiceVM> OurServices { get; set; }

        public AboutILGSectionVM AboutILGSectionVM { get; set; }

        public HtmlContentDetail HowWeWorkSectionContentDetail { get; set; }
        /** regarding steps we will return to it once we made the animation **/
        public ContactUsSectionVM ContactUsSectionViewModel { get; set; }

    }
}
