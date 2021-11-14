﻿using ILG_Global.BussinessLogic.Models;
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

        public SuccessStoriesVM SuccessStoriesViewModel { get; set; }

        public ContactUsSectionVM ContactUsSectionViewModel { get; set; }

        public HtmlContentDetail FooterLogoSummaryContent { get; set; }

        public NewsLetterSubscribe NewsLetterSubscribe { get; set; }
    }
}
