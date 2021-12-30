using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ILG_Global_Admin.BussinessLogic.Models
{
    public partial class HtmlContentMaster
    {
        public HtmlContentMaster()
        {
            HtmlContentDetails = new HashSet<HtmlContentDetail>();
            ImageMasters = new HashSet<ImageMaster>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }


        public bool IsHasTitle { get; set; }
        public bool IsHasSubTitle { get; set; }
        public bool IsHasSummary { get; set; }
        public bool IsHasDescription { get; set; }
        public bool IsHasImage { get; set; }



        public int ImageWidth { get; set; }
        public int ImageHeight { get; set; }





        public bool IsEnabled { get; set; }
        public bool CanBeDeletedByUser { get; set; }

        [InverseProperty(nameof(HtmlContentDetail.HtmlContent))]
        public virtual ICollection<HtmlContentDetail> HtmlContentDetails { get; set; }
        [InverseProperty(nameof(ImageMaster.HtmlContentMaster))]
        public virtual ICollection<ImageMaster> ImageMasters { get; set; }
    }
}
