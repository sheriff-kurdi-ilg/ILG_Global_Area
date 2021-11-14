using ILG_Global.BussinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.BussinessLogic.ViewModels
{
    public class ContactUsSectionVM
    {
        public HtmlContentDetail SuccessStoriesSectionHeaderContent { get; set; }

        public IEnumerable<ContactInformationDetail> ContactInformationDetails { get; set; }
    }
}
