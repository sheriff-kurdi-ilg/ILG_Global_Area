﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.BackEnd.BussinessLogic.Models
{
    public class ImageMaster
    {
        public int ID { get; set; }

        [ForeignKey("Section")]
        public int SectionID { get; set; }
        public SectionDetail Section { get; set; }
        public int Width { get; set; }

        public int Height { get; set; }
        public bool IsEnabled { get; set; }
    }
}
