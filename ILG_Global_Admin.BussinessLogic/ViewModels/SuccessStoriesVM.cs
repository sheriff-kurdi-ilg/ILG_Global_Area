﻿using ILG_Global_Admin.BussinessLogic.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global_Admin.BussinessLogic.ViewModels
{
    public class SuccessStoriesVM
    {
        [Required]
        public int SuccessStoryId { get; set; }
        [Required]
        public string ImageName { get; set; }
        [Required]
        public bool IsEnabled { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string PdfFileName { get; set; }
        [Required]
        [MaxLength(80)]
        public string Title { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Summary { get; set; }
        [Required]
        [Display(Name = "Title")]
        //[MaxLength(80)]
        public string TitleAr { get; set; }
        [Required]
        [Display(Name = "Summary")]
        //[MaxLength(500)]
        public string SummaryAr { get; set; }
        [Required]
        public string LanguageCode { get; set; }
        public IFormFile Image { get; set; }
        public string ImageURL { get; set; }
        public IFormFile Pdf { get; set; }
        public string PdfURL { get; set; }

    }
}
