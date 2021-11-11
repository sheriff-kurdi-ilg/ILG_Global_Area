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

        public List<OurServiceDetail> OurServiceDetails { get; set; }

        public HtmlContentDetail SuccessStoriesSectionHeaderContent { get; set; }

        public List<SucessStoryDetail> SucessStoryDetails { get; set; }

        /*
            <span>O</span>ur team of best family lawyers in Kuwait will help you stay ahead during these times of emotional distress. With our expert team of family lawyers, you will be girded with different strategies that will be helpful in your cause. You can be ensured that you will be well guided through every step of the legal proceedings by our family lawyers with an object to alleviate anxiety and reduce stress.
         */

    }
}
