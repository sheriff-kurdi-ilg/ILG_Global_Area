﻿using ILG_Global_Admin.BussinessLogic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global_Admin.BussinessLogic.ViewModels
{
    public class ContactUsSectionVM
    {
        //public HtmlContentDetail ContactUsSectionHeaderContent { get; set; }

        //public IEnumerable<ContactInformationDetail> ContactInformationDetails { get; set; }

        [Required]
        public int ContactUsMasterId { get; set; }
        public string FontAwsomeIconCssClass { get; set; }
       
        [Required]
        public bool IsEnabled { get; set; }


        public string NavigationURL { get; set; }

        [Required]
        public string LanguageCode { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        [Display(Name = "Text")]
        public string TextAr { get; set; }


    }


}
