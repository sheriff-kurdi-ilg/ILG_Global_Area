﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.BussinessLogic.Models
{
    public class HtmlContentMaster
    {
        public int ID { get; set; }
        public int ImageMasterId { get; set; }
        [ForeignKey("ImageMasterId")]
        public ImageMaster ImageMaster { get; set; }
        public bool IsEnabled { get; set; }
        public bool CanBeDeletedByUser { get; set; }
        public List<HtmlContentDetail> HtmlContentDetails { get; set; }
        
    }
}
