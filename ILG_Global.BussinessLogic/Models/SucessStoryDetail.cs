﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.BussinessLogic.Models
{
    public class SucessStoryDetail
    {
        public int SucessStoryMasterID { get; set; }
        [ForeignKey("SucessStoryMasterID")]
        public SucessStoryMaster SucessStoryMaster { get; set; }
        public string LanguageCode { get; set; }
        [ForeignKey("LanguageCode")]
        public Language Language { get; set; }
        public string Title { get; set; }

    }
}
