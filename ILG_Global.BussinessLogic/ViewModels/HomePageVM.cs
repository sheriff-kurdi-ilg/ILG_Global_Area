using ILG_Global.BussinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.BussinessLogic.ViewModels
{
    public class HomePageVM
    {
        public HtmlContentDetail LeaderBoardSectionHeaderContent{ get; set; }

        public IEnumerable<OurServiceDetail> OurServiceDetails { get; set; }

        public HtmlContentDetail SuccessStoriesSectionHeaderContent { get; set; }

        public IEnumerable<SucessStoryDetail> SucessStoryDetails { get; set; }

        public HtmlContentDetail ContactUsSectionHeaderContent { get; set; }
        public IEnumerable<ContactInformationDetail> ContactInformationDetails { get; set; }

        public HtmlContentDetail FooterLogoSummaryContent { get; set; }
    }
}
