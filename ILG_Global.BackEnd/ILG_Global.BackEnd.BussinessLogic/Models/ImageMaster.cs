﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.BackEnd.BussinessLogic.Models
{
    public class ImageMaster
    {
        public int ID { get; set; }
        public int Width { get; set; }

        public int Height { get; set; }
        public bool IsEnabled { get; set; }
    }
}
