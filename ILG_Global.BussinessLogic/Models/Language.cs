using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.BussinessLogic.Models
{
    public class Language
    {
        [Key]
        public string Code { get; set; }
        public int Title { get; set; }
    }
}
