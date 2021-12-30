using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global_Admin.BussinessLogic.ViewModels
{
    public class HtmlContentVM
    {
        [Required]
        public int HtmlContenID { get; set; }

        #region Master
        public bool IsEnabled { get; set; }
        public bool CanBeDeletedByUser { get; set; }

        public bool IsHasTitle { get; set; }
        public bool IsHasSubTitle { get; set; }
        public bool IsHasSummary { get; set; }
        public bool IsHasDescription { get; set; }
        public bool IsHasImage { get; set; }

        public IFormFile ImageAr { get; set; }
        public IFormFile ImageEn { get; set; }
        public string ImageURLAr { get; set; }
        public string ImageURLEn { get; set; }
        public int ImageWidth { get; set; }
        public int ImageHeight { get; set; }


        #endregion

        #region Detail
        // [Required]
        [MaxLength(80)]
        public string Title { get; set; }
        // [Required]
        [MaxLength(80)]
        public string TitleAr { get; set; }
        [MaxLength(80)]
        [Required]
        public string SubTitle { get; set; }
        [MaxLength(80)]
        [Required]
        public string SubTitleAr { get; set; }
        [Required]
        [MaxLength(500)]
        public string Summary { get; set; }
        [Required]
        [MaxLength(500)]
        public string SummaryAr { get; set; }
        [Required]
        public string LanguageCode { get; set; }
        #endregion
    }
}
