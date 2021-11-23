using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.BussinessLogic.Models
{
    public class ShareViaEmailSubscriber
    {
        public int ID { get; set; }
        [Required]
        public string EmailAddress { get; set; }
    }
}
