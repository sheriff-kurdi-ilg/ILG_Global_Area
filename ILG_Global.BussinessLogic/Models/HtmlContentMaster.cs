﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.BussinessLogic.Models
{
    public class HtmlContentMaster
    {
        public int ID { get; set; }
        public string ImageName { get; set; }
        public bool IsEnabled { get; set; }
        public bool CanBeDeletedByUser { get; set; }
        public List<HtmlContentDetail> HtmlContentDetails { get; set; }
        
    }
}